namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to manage <see cref="Agent"/>s.
/// </summary>
public interface IAgentRegistry
{

    /// <summary>
    /// Registers a new agent.
    /// </summary>
    /// <param name="metadata">The metadata used to describe the agent to register.</param>
    /// <param name="specs">The specs of the agent to register.</param>
    void Register(AgentMetadata metadata, AgentSpecs specs);

    /// <summary>
    /// Deregisters the specified agent.
    /// </summary>
    /// <param name="id">The unique identifier of the agent to deregister.</param>
    void Deregister(string id);

    /// <summary>
    /// Gets the agent with the specified id.
    /// </summary>
    /// <param name="id">The id of the agent to get.</param>
    /// <returns>The specified agent.</returns>
    IAgentRecord Get(string id);

    /// <summary>
    /// Gets the agent with the specified name and version.
    /// </summary>
    /// <param name="name">The name of the agent to get.</param>
    /// <param name="version">The version of the agent to get.</param>
    /// <returns>The specified agent</returns>
    IAgentRecord Get(string name, string version);

    /// <summary>
    /// Lists all registered agents.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/> containing all registered agents.</returns>
    IEnumerable<IAgentRecord> List();

}
