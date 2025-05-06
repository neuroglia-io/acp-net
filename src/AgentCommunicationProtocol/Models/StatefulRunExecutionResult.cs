namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the result of a stateful run's execution.
/// </summary>
[Description("Represents the result of a stateful run's execution.")]
[DataContract]
public record StatefulRunExecutionResult
{

    /// <summary>
    /// Gets or sets the run that has been executed.
    /// </summary>
    [Description("The run that has been executed.")]
    [Required]
    [DataMember(Name = "run", Order = 1), JsonPropertyName("run"), JsonPropertyOrder(1), YamlMember(Alias = "run", Order = 1)]
    public virtual required StatefulRun Run { get; set; }

    /// <summary>
    /// Gets or sets the run's output.
    /// </summary>
    [Description("The run's output.")]
    [Required]
    [DataMember(Name = "output", Order = 2), JsonPropertyName("output"), JsonPropertyOrder(2), YamlMember(Alias = "output", Order = 2)]
    public virtual required RunOutput Output { get; set; }

}
