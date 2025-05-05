namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an agent's record.
/// </summary>
[Description("Represents an agent's record.")]
[DataContract]
public record AgentRecord
    : IAgentRecord
{

    /// <summary>
    /// Gets or sets the agent's unique identifier.
    /// </summary>
    [Description("The agent's unique identifier.")]
    [DataMember(Name = "agent_id", Order = 1), JsonPropertyName("agent_id"), JsonPropertyOrder(1), YamlMember(Alias = "agent_id", Order = 1)]
    public virtual required string Id { get; set; }

    /// <summary>
    /// Gets or sets the agent's metadata.
    /// </summary>
    [Description("The agent's metadata.")]
    [DataMember(Name = "metadata", Order = 2), JsonPropertyName("metadata"), JsonPropertyOrder(2), YamlMember(Alias = "metadata", Order = 2)]
    public virtual required AgentMetadata Metadata { get; set; }

    /// <summary>
    /// Gets or sets the specification of the agent's capabilities, config, input, output, and interrupts.
    /// </summary>
    [Description("The specification of the agent's capabilities, config, input, output, and interrupts.")]
    [DataMember(Name = "specs", Order = 3), JsonPropertyName("specs"), JsonPropertyOrder(3), YamlMember(Alias = "specs", Order = 3)]
    public virtual required AgentSpecs Specs { get; set; }

    /// <inheritdoc/>
    public override string ToString() => Id;

}