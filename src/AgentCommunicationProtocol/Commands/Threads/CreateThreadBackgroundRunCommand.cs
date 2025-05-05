using AgentCommunicationProtocol.Commands.Runs;

namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to create a new background run on a thread.
/// </summary>
[Description("Represents the command used to create a new background run on a thread.")]
[DataContract]
public class CreateThreadBackgroundRunCommand
    : Command<StatefulAgentRun>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread on which to create a new background run.
    /// </summary>
    [Description("The unique identifier of the thread on which to create a new background run.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the command that defines the background run to create on the thread.
    /// </summary>
    [Description("The unique identifier of the thread to create a new background run for.")]
    [Required]
    [DataMember(Name = "run", Order = 2), JsonPropertyName("run"), JsonPropertyOrder(2), YamlMember(Alias = "run", Order = 2)]
    public virtual required CreateStatefulRunCommand Run { get; set; } 

}
