using System.Threading.Channels;

namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents the default implementation of the <see cref="IBackgroundWorker"/> interface
/// </summary>
/// <param name="serviceProvider">The current <see cref="IServiceProvider"/></param>
public class BackgroundWorker(IServiceProvider serviceProvider)
    : BackgroundService, IBackgroundWorker
{

    /// <summary>
    /// Gets the current <see cref="IServiceProvider"/>
    /// </summary>
    protected IServiceProvider ServiceProvider { get; } = serviceProvider;

    /// <summary>
    /// Gets the <see cref="Channel{T}"/> used to enqueue pending jobs
    /// </summary>
    protected Channel<Job> Queue { get; } = Channel.CreateUnbounded<Job>();

    /// <summary>
    /// Gets a <see cref="ConcurrentDictionary{TKey, TValue}"/> containing id/<see cref="TaskCompletionSource"/> mappings of pending, awaited jobs
    /// </summary>
    protected ConcurrentDictionary<Guid, TaskCompletionSource> PendingJobs { get; } = new();

    /// <summary>
    /// Gets the <see cref="BackgroundWorker"/>'s <see cref="System.Threading.CancellationTokenSource"/>
    /// </summary>
    protected CancellationTokenSource CancellationTokenSource { get; private set; } = null!;

    /// <inheritdoc/>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        this.CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
        _ = PerformJobAsync();
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public virtual async Task EnqueueJobAsync(Func<IServiceProvider, CancellationToken, Task> delegateFunction, bool waitForCompletion = false, CancellationToken cancellationToken = default)
    {
        var job = new Job(delegateFunction, CancellationTokenSource.CreateLinkedTokenSource(cancellationToken));
        TaskCompletionSource? taskCompletionSource = null;
        if (waitForCompletion)
        {
            taskCompletionSource = new TaskCompletionSource();
            PendingJobs.TryAdd(job.Id, taskCompletionSource);
        }
        await Queue.Writer.WriteAsync(job, cancellationToken).ConfigureAwait(false);
        if (taskCompletionSource != null) await taskCompletionSource.Task.ConfigureAwait(false);
    }

    /// <summary>
    /// Performs pending jobs
    /// </summary>
    /// <returns>A new awaitable <see cref="Task"/></returns>
    protected virtual async Task PerformJobAsync()
    {
        try
        {
            do
            {
                using var job = await Queue.Reader.ReadAsync(CancellationTokenSource.Token).ConfigureAwait(false);
                if (job == null)
                {
                    await Task.Delay(5).ConfigureAwait(false);
                    continue;
                }
                Exception? exception = null;
                if (!job.CancellationTokenSource.IsCancellationRequested)
                {
                    using var scope = ServiceProvider.CreateScope();
                    try
                    {
                        var task = job.Delegate.Invoke(scope.ServiceProvider, job.CancellationTokenSource.Token);
                        await task.ConfigureAwait(false);
                    }
                    catch (Exception ex) { exception = ex; }
                }
                if (PendingJobs.TryRemove(job.Id, out var taskCompletionSource))
                {
                    if (exception == null) taskCompletionSource.SetResult();
                    else taskCompletionSource.SetException(exception);
                }
            }
            while (!CancellationTokenSource.IsCancellationRequested);
        }
        catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException) { }
    }

    /// <inheritdoc/>
    public override void Dispose()
    {
        base.Dispose();
        CancellationTokenSource?.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Represents a job
    /// </summary>
    /// <param name="delegate">The job's delegate function</param>
    /// <param name="cancellationTokenSource">The <see cref="Job"/>'s <see cref="System.Threading.CancellationTokenSource"/></param>
    protected class Job(Func<IServiceProvider, CancellationToken, Task> @delegate, CancellationTokenSource cancellationTokenSource)
        : IDisposable
    {

        /// <summary>
        /// Gets the job's id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets the job's delegate function
        /// </summary>
        public Func<IServiceProvider, CancellationToken, Task> Delegate { get; } = @delegate;

        /// <summary>
        /// Gets the <see cref="Job"/>'s <see cref="System.Threading.CancellationTokenSource"/>
        /// </summary>
        public CancellationTokenSource CancellationTokenSource { get; } = cancellationTokenSource;

        /// <inheritdoc/>
        public void Dispose() => CancellationTokenSource.Dispose();

    }

}
