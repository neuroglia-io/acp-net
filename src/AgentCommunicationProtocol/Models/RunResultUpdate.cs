namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the base class for all run result updates.
/// </summary>
[Description("Represents the base class for all run result updates.")]
[DataContract]
public abstract record RunResultUpdate
{

    /// <summary>
    /// Gets or sets the type of the run result update
    /// </summary>
    public abstract string Type { get; }

    /// <summary>
    /// Gets or sets the identifier of the run to describe a result update of.
    /// </summary>
    [Description("The unique identifier of the run to describe a result update of.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 2), JsonPropertyName("run_id"), JsonPropertyOrder(2), YamlMember(Alias = "run_id", Order = 2)]
    public virtual required string RunId { get; set; }

    /// <summary>
    /// Gets or sets the status of the Run when this result was generated. This is useful when this data structure is used for streaming results. As the server can indicate an interrupt or an error condition while streaming the result.
    /// </summary>
    [Description("The status of the Run when this result was generated. This is useful when this data structure is used for streaming results. As the server can indicate an interrupt or an error condition while streaming the result.")]
    [Required, AllowedValues(RunStatus.Error, RunStatus.Interrupted, RunStatus.Pending, RunStatus.Success, RunStatus.Timeout)]
    [DataMember(Name = "status", Order = 3), JsonPropertyName("status"), JsonPropertyOrder(3), YamlMember(Alias = "status", Order = 3)]
    public virtual required string Status { get; set; }

}
