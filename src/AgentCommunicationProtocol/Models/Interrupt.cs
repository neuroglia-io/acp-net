namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the declaration of an agent's interrupt.
/// </summary>
[Description("Represents the declaration of an agent's interrupt.")]
[DataContract]
public record Interrupt
{

    /// <summary>
    /// Gets/sets the interrupt's type. Needs to be unique in the list of interrupts.
    /// </summary>
    [Description("The interrupt's type. Needs to be unique in the list of interrupts.")]
    [Required, MinLength(1)]
    [DataMember(Name = "interrupt_type", Order = 1), JsonPropertyName("interrupt_type"), JsonPropertyOrder(1), YamlMember(Alias = "interrupt_type", Order = 1)]
    public virtual string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets a JSON schema used to describe the interrupt's payload.
    /// </summary>
    [Description("A JSON schema used to describe the interrupt's payload.")]
    [Required]
    [DataMember(Name = "interrupt_payload", Order = 2), JsonPropertyName("interrupt_payload"), JsonPropertyOrder(2), YamlMember(Alias = "interrupt_payload", Order = 2)]
    public virtual JsonSchema Payload { get; set; } = null!;

    /// <summary>
    /// Gets or sets a JSON schema used to describe the interrupt resume payload.
    /// </summary>
    [Description("A JSON schema used to describe the interrupt resume payload.")]
    [Required]
    [DataMember(Name = "resume_payload", Order = 3), JsonPropertyName("resume_payload"), JsonPropertyOrder(3), YamlMember(Alias = "resume_payload", Order = 3)]
    public virtual JsonSchema ResumePayload { get; set; } = null!;

}
