namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the declaration of the streaming modes supported by an agent.
/// </summary>
[Description("Represents the declaration of the streaming modes supported by an agent.")]
[DataContract]
public record StreamingModes
{

    /// <summary>
    /// Gets or sets a boolean indicating whether the agent supports values streaming. Defaults to false.
    /// </summary>
    [Description("A boolean indicating whether the agent supports values streaming. Defaults to false.")]
    [DefaultValue(false)]
    [DataMember(Name = "values", Order = 1), JsonPropertyName("values"), JsonPropertyOrder(1), YamlMember(Alias = "values", Order = 1)]
    public virtual bool Values { get; set; }

    /// <summary>
    /// Gets or sets a boolean indicating whether the agent supports custom objects streaming. Defaults to false.
    /// </summary>
    [Description("A boolean indicating whether the agent supports custom objects streaming. Defaults to false.")]
    [DefaultValue(false)]
    [DataMember(Name = "custom", Order = 2), JsonPropertyName("custom"), JsonPropertyOrder(2), YamlMember(Alias = "custom", Order = 2)]
    public virtual bool Custom { get; set; }

}