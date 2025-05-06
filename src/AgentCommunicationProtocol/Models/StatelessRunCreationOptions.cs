namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the options used to create a new stateless run.
/// </summary>
[Description("Represents the options used to create a new stateless run.")]
[DataContract]
public record StatelessRunCreationOptions
    : RunCreationOptions
{

    /// <summary>
    /// Gets/sets the run's completion mode.
    /// </summary>
    [Description("The run's completion mode..")]
    [Required, AllowedValues(RunCompletionMode.Delete, RunCompletionMode.Keep), DefaultValue(RunCompletionMode.Delete)]
    [DataMember(Name = "on_completion", Order = 10), JsonPropertyName("on_completion"), JsonPropertyOrder(10), YamlMember(Alias = "on_completion", Order = 10)]
    public virtual string OnCompletion { get; set; } = RunCompletionMode.Delete;

}