namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to perform jobs in the background
/// </summary>
public interface IBackgroundWorker
    : IHostedService
{

    /// <summary>
    /// Enqueues, and optionally awaits, the specified delegate to be executed in a sequential manner
    /// </summary>
    /// <param name="delegateFunction">The delegate function that represents the job to enqueue</param>
    /// <param name="waitForCompletion">A boolean indicating whether or not to await for the task's completion</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
    /// <returns>A new awaitable <see cref="Task"/></returns>
    Task EnqueueJobAsync(Func<IServiceProvider, CancellationToken, Task> delegateFunction, bool waitForCompletion = false, CancellationToken cancellationToken = default);

}

