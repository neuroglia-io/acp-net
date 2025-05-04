namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the parameters used to create a new agent stateless run.
/// </summary>
[Description("Represents the parameters used to create a new agent stateless run.")]
public record AgentStatelelessRunParameters
    : AgentRunParameters
{

    /// <summary>
    /// Gets/sets the completion mode to use. Defaults to 'delete'.
    /// </summary>
    [Description("The completion mode to use. Defaults to 'delete'.")]
    [AllowedValues(RunCompletionMode.Delete, RunCompletionMode.Keep), DefaultValue(RunDisconnectMode.Cancel)]
    [DataMember(Name = "on_completion", Order = 10), JsonPropertyName("on_completion"), JsonPropertyOrder(10), YamlMember(Alias = "on_completion", Order = 10)]
    public virtual string OnCompletion { get; set; } = RunCompletionMode.Delete;

}
