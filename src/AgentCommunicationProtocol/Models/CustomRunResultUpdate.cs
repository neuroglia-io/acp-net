namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a custom defined update of a run result during streaming.
/// </summary>
[Description("Represents a custom defined update of a run result during streaming.")]
[DataContract]
public record CustomRunResultUpdate
    : RunResultUpdate
{

    /// <summary>
    /// Gets or sets the type of the run result update
    /// </summary>
    [Description("The type of the run result update.")]
    [Required, MinLength(1)]
    [DataMember(Name = "type", Order = 1), JsonPropertyName("type"), JsonPropertyOrder(1), YamlMember(Alias = "type", Order = 1)]
    public override string Type => StreamingMode.Custom;

    /// <summary>
    /// Gets or sets update in the SSE event streaming where streaming mode is set to 'custom'. The schema is described in agent ACP descriptor under 'spec.custom_streaming_update'.
    /// </summary>
    [Description("The update in the SSE event streaming where streaming mode is set to 'custom'. The schema is described in agent ACP descriptor under 'spec.custom_streaming_update'.")]
    [Required]
    [DataMember(Name = "values", Order = 4), JsonPropertyName("values"), JsonPropertyOrder(4), YamlMember(Alias = "values", Order = 4)]
    public virtual EquatableDictionary<string, object> Update { get; set; } = null!;

}