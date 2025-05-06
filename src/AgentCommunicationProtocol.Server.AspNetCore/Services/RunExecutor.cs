namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents the default implementation of the <see cref="IRunExecutor"/> interface.
/// </summary>
/// <param name="logger">The service used to perform logging.</param>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s.</param>
/// <param name="agentRuntimeFactory">The service used to create <see cref="IAgentRuntime"/>s.</param>
public class RunExecutor(ILogger<RunExecutor> logger, IThreadStore threadStore, IAgentRuntimeFactory agentRuntimeFactory)
    : IRunExecutor
{

    /// <summary>
    /// Gets the service used to perform logging.
    /// </summary>
    protected ILogger Logger { get; } = logger;

    /// <summary>
    /// Gets the service used to manage <see cref="Models.Thread"/>s.
    /// </summary>
    protected IThreadStore ThreadStore { get; } = threadStore;

    /// <summary>
    /// Gets the service used to create <see cref="IAgentRuntime"/>s.
    /// </summary>
    protected IAgentRuntimeFactory AgentRuntimeFactory { get; } = agentRuntimeFactory;

    /// <summary>
    /// Gets the collection of contexts for currently executing runs, indexed by id.
    /// </summary>
    protected ConcurrentDictionary<string, RunExecutionContext> ExecutionContexts { get; } = [];

    /// <inheritdoc/>
    public virtual async IAsyncEnumerable<RunOutputStreamEvent> ExecuteAsync(Run run, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (run.Status != RunStatus.Pending) throw new ProblemDetailsException(Problems.UnexpectedRunStatus(run.Id, run.Status));
        var agent = AgentRuntimeFactory.Create(run.AgentId);
        var input = run switch
        {
            StatefulRun statefulRun => statefulRun.Creation.Input,
            _ => throw new NotSupportedException($"The specified run type is not supported")
        };
        object? interrupt = null;
        using var interruptSubscription = agent.Where(r => r.RunId == run.Id).Subscribe(r =>
        {
            interrupt = r.Payload;
        });
        RunOutput? output;
        var defaultAuthorRole = "assistant";
        var message = new Message()
        {
            Id = Guid.NewGuid().ToString("N"),
            Role = defaultAuthorRole
        };
        var outputStream = new Subject<RunOutputStreamEvent>();
        var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var executionContext = new RunExecutionContext()
        {
            OutputStream = outputStream,
            CancellationTokenSource = cancellationTokenSource
        };
        ExecutionContexts.TryAdd(run.Id, executionContext);
        await foreach (var streamingContent in agent.ExecuteAsync(input, executionContext.CancellationTokenSource.Token).ConfigureAwait(false))
        {
            try
            {
                if (interrupt != null) yield break;
                var block = new MessageTextBlock
                {
                    Text = streamingContent.Content?.Trim()!,
                    Type = "text",
                    Metadata = streamingContent.Metadata == null ? null : new(streamingContent.Metadata)
                };
                message.Role = streamingContent.Role ?? defaultAuthorRole;
                message.Content ??= [];
                message.Content.Add(block);
            }
            catch (Exception ex)
            {
                Logger.LogError("An error occurred while executing the run with id '{runId}': {ex}", run.Id, ex);
                output = new RunError()
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Description = ex.Message
                };
                break;
            }
            var e = new RunOutputStreamEvent
            {
                Id = Guid.NewGuid().ToString("N"),
                Data = new ValueRunResultUpdate()
                {
                    RunId = run.Id,
                    Status = RunStatus.Pending,
                    Messages = [message]
                }
            };
            outputStream.OnNext(e);
            yield return e;
        }
        outputStream.OnCompleted();
        ExecutionContexts.Remove(run.Id, out _);
        if (interrupt == null) output = new RunResult()
        {
            Messages = [message]
        };
        else output = new RunInterrupt()
        {
            Interrupt = interrupt
        };
        switch (run)
        {
            case StatefulRun statefulRun:
                await ThreadStore.SetRunOutputAsync(run.ThreadId!, run.Id, output, executionContext.CancellationTokenSource.Token).ConfigureAwait(false);
                break;
        }
        executionContext.Dispose();
    }

    /// <inheritdoc/>
    public virtual IAsyncEnumerable<RunOutputStreamEvent> StreamOutputAsync(string runId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        if (ExecutionContexts.TryGetValue(runId, out var context) && context != null) return context.OutputStream.ToAsyncEnumerable();
        else return AsyncEnumerable.Empty<RunOutputStreamEvent>();
    }

    /// <inheritdoc/>
    public virtual async Task CancelAsync(string runId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(runId);
        if (!ExecutionContexts.TryGetValue(runId, out var context) || context == null) return;
        await context.CancellationTokenSource.CancelAsync().ConfigureAwait(false);
        context.Dispose();
        ExecutionContexts.Remove(runId, out _);
    }

}
