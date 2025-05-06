namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Defines the fundamentals of an agent record
/// </summary>
public interface IAgentRecord
{

    /// <summary>
    /// Gets the agent's unique identifier.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the agent's metadata.
    /// </summary>
    AgentMetadata Metadata { get; }

    /// <summary>
    /// Gets the specification of the agent's capabilities, config, input, output, and interrupts.
    /// </summary>
    AgentSpecs Specs { get; }

    /// <summary>
    /// Gets the delegate function used to create the agent's <see cref="IAgentRuntime"/>.
    /// </summary>
    AgentRuntimeFactoryDelegate RuntimeFactory { get; }

    /// <summary>
    /// Converts the <see cref="AgentRecord"/> into a new <see cref="Agent"/>.
    /// </summary>
    /// <returns>A new <see cref="Agent"/>.</returns>
    Agent AsAgent() => new()
    {
        Id = Id,
        Metadata = Metadata
    };

    /// <summary>
    /// Converts the <see cref="AgentRecord"/> into a new <see cref="AgentDescriptor"/>.
    /// </summary>
    /// <returns>A new <see cref="AgentDescriptor"/>.</returns>
    AgentDescriptor AsDescriptor() => new()
    {
        Metadata = Metadata,
        Specs = Specs
    };

}
