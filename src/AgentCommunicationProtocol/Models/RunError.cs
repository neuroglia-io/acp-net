namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an error that occurred during a run's execution.
/// </summary>
[Description("Represents an error that occurred during a run's execution.")]
[DataContract]
public record RunError
    : RunOutput
{

    /// <summary>
    /// Gets or sets the output type.
    /// </summary>
    [Description("The output type.")]
    [IgnoreDataMember, JsonIgnore, YamlIgnore]
    public override string Type => RunOutputType.Error;

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    [Description("The error code.")]
    [Required]
    [DataMember(Name = "errcode", Order = 2), JsonPropertyName("errcode"), JsonPropertyOrder(2), YamlMember(Alias = "errcode", Order = 2)]
    public virtual required int Code { get; set; }

    /// <summary>
    /// Gets or sets the error's description.
    /// </summary>
    [Description("The error's description.")]
    [Required, MinLength(1)]
    [DataMember(Name = "description", Order = 3), JsonPropertyName("description"), JsonPropertyOrder(3), YamlMember(Alias = "description", Order = 3)]
    public virtual required string Description { get; set; }

}