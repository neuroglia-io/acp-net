namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to cancel a pending run.
/// </summary>
[Description("Represents the command used to cancel a pending run")]
[DataContract]
public class CancelThreadRunCommand
    : Command
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread the run to cancel belongs to.
    /// </summary>
    [Description("The unique identifier of the thread the run to cancel belongs to.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier the run to cancel.
    /// </summary>
    [Description("The unique identifier the run to cancel.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 2), JsonPropertyName("run_id"), JsonPropertyOrder(2), YamlMember(Alias = "run_id", Order = 2)]
    public virtual required string RunId { get; set; }

    /// <summary>
    /// Gets or sets a boolean indicating whether to wait for the run to be cancelled
    /// </summary>
    [Description("A boolean indicating whether to wait for the run to be cancelled.")]
    [DataMember(Name = "wait", Order = 3), JsonPropertyName("wait"), JsonPropertyOrder(3), YamlMember(Alias = "wait", Order = 3)]
    public virtual required bool Wait { get; set; }

    /// <summary>
    /// Gets or sets the cancellation action to take.
    /// </summary>
    [Description("The cancellation action to take.")]
    [Required, AllowedValues(RunCancellationAction.Interrupt, RunCancellationAction.Rollback), DefaultValue(RunCancellationAction.Interrupt)]
    [DataMember(Name = "action", Order = 4), JsonPropertyName("action"), JsonPropertyOrder(4), YamlMember(Alias = "action", Order = 4)]
    public virtual required string Action { get; set; } = RunCancellationAction.Interrupt;

}