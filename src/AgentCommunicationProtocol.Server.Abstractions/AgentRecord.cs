namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Represents an agent's record.
/// </summary>
public record AgentRecord
    : IAgentRecord
{

    /// <summary>
    /// Gets or sets the agent's unique identifier.
    /// </summary>
    public virtual required string Id { get; init; }

    /// <summary>
    /// Gets or sets the agent's metadata.
    /// </summary>
    public virtual required AgentMetadata Metadata { get; init; }

    /// <summary>
    /// Gets or sets the specification of the agent's capabilities, config, input, output, and interrupts.
    /// </summary>
    public virtual required AgentSpecs Specs { get; init; }

    /// <summary>
    /// Gets or sets the delegate used to create the agent's <see cref="IAgentRuntime"/>.
    /// </summary>
    public virtual required AgentRuntimeFactoryDelegate RuntimeFactory { get; init; }

    /// <inheritdoc/>
    public override string ToString() => Id;

}
