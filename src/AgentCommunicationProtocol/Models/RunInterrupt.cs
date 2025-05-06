namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an interrupt that occurred during a run.
/// </summary>
[Description("Represents an interrupt that occurred during a run.")]
[DataContract]
public record RunInterrupt
    : RunOutput
{

    /// <summary>
    /// Gets or sets the output type.
    /// </summary>
    [Description("The output type.")]
    [IgnoreDataMember, JsonIgnore, YamlIgnore]
    public override string Type => RunOutputType.Interrupt;

    /// <summary>
    /// Gets or sets the interrupt payload.
    /// </summary>
    [Description("The interrupt payload.")]
    [Required]
    [DataMember(Name = "interrupt", Order = 2), JsonPropertyName("interrupt"), JsonPropertyOrder(2), YamlMember(Alias = "interrupt", Order = 2)]
    public virtual required object Interrupt { get; set; }

}
