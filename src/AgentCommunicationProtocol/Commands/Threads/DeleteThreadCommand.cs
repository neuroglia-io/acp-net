namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to delete a thread.
/// </summary>
[Description("Represents the command used to delete a thread.")]
[DataContract]
public class DeleteThreadCommand
    : Command
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread to delete.
    /// </summary>
    [Description("The unique identifier of the thread to delete.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual string ThreadId { get; set; } = null!;

}
