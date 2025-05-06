namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to stream the output of a pending run.
/// </summary>
[Description("Represents the command used to stream the output of a pending run.")]
[DataContract]
public class StreamThreadRunOutputCommand
    : Command<IAsyncEnumerable<RunOutputStreamEvent>>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread the run to stream the output of belongs to.
    /// </summary>
    [Description("The unique identifier of the thread the run to stream the output of belongs to.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier the run to stream the output of.
    /// </summary>
    [Description("The unique identifier the run to stream the output of.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 2), JsonPropertyName("run_id"), JsonPropertyOrder(2), YamlMember(Alias = "run_id", Order = 2)]
    public virtual required string RunId { get; set; }

}