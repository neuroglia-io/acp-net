namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to create <see cref="IAgentRuntime"/>s
/// </summary>
public interface IAgentRuntimeFactory
{

    /// <summary>
    /// Creates a new <see cref="IAgentRuntime"/>.
    /// </summary>
    /// <param name="agentId">The unique identifier of the agent to create a new <see cref="IAgentRuntime"/> for.</param>
    /// <returns>A new <see cref="IAgentRuntime"/> used to interact with the specified agent.</returns>
    IAgentRuntime Create(string agentId);

}