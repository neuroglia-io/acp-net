namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the basic information associated to an agent.
/// </summary>
[Description("Represents the basic information associated to an agent.")]
[DataContract]
public record AgentMetadata
{

    /// <summary>
    /// Gets or sets a reference to the Agent Record in the Agent Directory.
    /// </summary>
    [Description("A reference to the Agent Record in the Agent Directory.")]
    [Required]
    [DataMember(Name = "ref", Order = 1), JsonPropertyName("ref"), JsonPropertyOrder(1), YamlMember(Alias = "ref", Order = 1)]
    public virtual AgentReference Ref { get; set; } = null!;

    /// <summary>
    /// Gets or sets the agent's description, which should include what the intended use is, what tasks it accomplishes and how uses input and configs to produce the output and any other side effect.
    /// </summary>
    [Description("The agent's description, which should include what the intended use is, what tasks it accomplishes and how uses input and configs to produce the output and any other side effect.")]
    [Required, MinLength(1)]
    [DataMember(Name = "description", Order = 2), JsonPropertyName("description"), JsonPropertyOrder(2), YamlMember(Alias = "description", Order = 2)]
    public virtual string Description { get; set; } = null!;

    /// <inheritdoc/>
    public override string ToString() => Ref.ToString();

}
