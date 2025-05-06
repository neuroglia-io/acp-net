namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to resume an interrupted run.
/// </summary>
[Description("Represents the command used to resume an interrupted run.")]
[DataContract]
public class ResumeThreadRunCommand
    : Command<StatefulRun>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread the run to resume belongs to.
    /// </summary>
    [Description("The unique identifier of the thread the run to resume belongs to.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier the run to resume.
    /// </summary>
    [Description("The unique identifier the run to resume.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 2), JsonPropertyName("run_id"), JsonPropertyOrder(2), YamlMember(Alias = "run_id", Order = 2)]
    public virtual required string RunId { get; set; }

    /// <summary>
    /// Gets or sets the interrupt's payload.
    /// </summary>
    [Description("The interrupt's payload.")]
    [Required, MinLength(1)]
    [DataMember(Name = "payload", Order = 3), JsonPropertyName("payload"), JsonPropertyOrder(3), YamlMember(Alias = "payload", Order = 3)]
    public virtual required object Payload { get; set; }

}
