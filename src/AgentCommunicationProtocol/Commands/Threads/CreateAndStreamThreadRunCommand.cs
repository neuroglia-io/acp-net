using AgentCommunicationProtocol.Commands.Runs;

namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to create a run on a thread and to stream its output.
/// </summary>
[Description("Represents the command used to create a run on a thread and to stream its output.")]
[DataContract]
public class CreateAndStreamThreadRunCommand
    : Command<IAsyncEnumerable<RunResultUpdate>>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread on which to create a new run.
    /// </summary>
    [Description("The unique identifier of the thread on which to create a new run.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the command that defines the run to create on the thread.
    /// </summary>
    [Description("The unique identifier of the thread to create a new run for.")]
    [Required]
    [DataMember(Name = "run", Order = 2), JsonPropertyName("run"), JsonPropertyOrder(2), YamlMember(Alias = "run", Order = 2)]
    public virtual required CreateStatefulRunCommand Run { get; set; }

}
