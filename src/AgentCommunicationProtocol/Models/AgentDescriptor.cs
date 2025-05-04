namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the ACP specs of an agent, including schemas and protocol features.
/// </summary>
[Description("Represents the ACP specs of an agent, including schemas and protocol features.")]
[DataContract]
public record AgentDescriptor
{

    /// <summary>
    /// Gets or sets the agent's metadata.
    /// </summary>
    [Description("The agent's metadata.")]
    [Required]
    [DataMember(Name = "metadata", Order = 1), JsonPropertyName("metadata"), JsonPropertyOrder(1), YamlMember(Alias = "metadata", Order = 1)]
    public virtual AgentMetadata Metadata { get; set; } = null!;

    /// <summary>
    /// Gets or sets the specification of the agent's capabilities, config, input, output, and interrupts.
    /// </summary>
    [Description("The specification of the agent's capabilities, config, input, output, and interrupts.")]
    [Required]
    [DataMember(Name = "specs", Order = 2), JsonPropertyName("specs"), JsonPropertyOrder(2), YamlMember(Alias = "specs", Order = 2)]
    public virtual AgentSpecs Specs { get; set; } = null!;

    /// <inheritdoc/>
    public override string ToString() => Metadata.ToString();

}
