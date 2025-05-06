namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to interact with an AI agent to execute tasks
/// </summary>
public interface IAgentRuntime
    : IObservable<InterruptRequest>
{

    /// <summary>
    /// Executes the specified run and streams the content produced by the agent
    /// </summary>
    /// <param name="input">The input to process</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to stream the content produced by the agent during the run's execution</returns>
    IAsyncEnumerable<AgentStreamingMessageContent> ExecuteAsync(object input, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the specified task's execution
    /// </summary>
    /// <param name="taskId">The id of the task to cancel.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
    /// <returns>A new awaitable <see cref="Task"/></returns>
    Task CancelAsync(string taskId, CancellationToken cancellationToken = default);

}