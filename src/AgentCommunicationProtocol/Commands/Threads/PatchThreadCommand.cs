namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to patch a thread.
/// </summary>
[Description("Represents the command used to patch a thread.")]
[DataContract]
public class PatchThreadCommand
    : Command<Models.Thread>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread to patch.
    /// </summary>
    [Description("The unique identifier of the thread to patch.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the thread's updated state.
    /// </summary>
    [Description("The thread's updated state.")]
    [Required]
    [DataMember(Name = "state", Order = 2), JsonPropertyName("state"), JsonPropertyOrder(2), YamlMember(Alias = "state", Order = 2)]
    public virtual required Models.ThreadState State { get; set; }

}