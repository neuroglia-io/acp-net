namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the service used to execute runs.
/// </summary>
public interface IRunExecutor
{

    /// <summary>
    /// Executes the specified <see cref="Run"/>.
    /// </summary>
    /// <param name="run">The <see cref="Run"/> to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to stream the run's outputs.</returns>
    IAsyncEnumerable<RunOutputStreamEvent> ExecuteAsync(Run run, CancellationToken cancellationToken = default);

    /// <summary>
    /// Streams the output of the specified run.
    /// </summary>
    /// <param name="runId">The unique identifier of the run to stream the output of.</param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to stream the run's outputs.</returns>
    IAsyncEnumerable<RunOutputStreamEvent> StreamOutputAsync(string runId);

    /// <summary>
    /// Cancels the specified run.
    /// </summary>
    /// <param name="runId">The unique identifier of the run to cancel.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new awaitable <see cref="Task"/>.</returns>
    Task CancelAsync(string runId, CancellationToken cancellationToken = default);

}