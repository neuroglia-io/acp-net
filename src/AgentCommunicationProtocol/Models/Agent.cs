namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the description of an agent.
/// </summary>
[Description("Represents the description of an agent.")]
[DataContract]
public record Agent
{

    /// <summary>
    /// Gets or sets the agent's unique identifier.
    /// </summary>
    [Description("The agent's unique identifier.")]
    [Required, MinLength(1)]
    [DataMember(Name = "agent_id", Order = 1), JsonPropertyName("agent_id"), JsonPropertyOrder(1), YamlMember(Alias = "agent_id", Order = 1)]
    public virtual string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the agent's metadata.
    /// </summary>
    [Description("The agent's metadata.")]
    [Required]
    [DataMember(Name = "metadata", Order = 2), JsonPropertyName("metadata"), JsonPropertyOrder(2), YamlMember(Alias = "metadata", Order = 2)]
    public virtual AgentMetadata Metadata { get; set; } = null!;

    /// <inheritdoc/>
    public override string ToString() => Id;

}
