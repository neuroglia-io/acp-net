namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a thread lifecycle event.
/// </summary>
[Description("Represents a thread lifecycle event.")]
[DataContract]
public record ThreadLifecycleEvent
{

    /// <summary>
    /// Gets or sets the lifecycle event's type
    /// </summary>
    [Description("The lifecycle event's type")]
    [Required, AllowedValues(ThreadLifecycleEventType.Created, ThreadLifecycleEventType.Patched, ThreadLifecycleEventType.Deleted)]
    [DataMember(Name = "type", Order = 1), JsonPropertyName("type"), JsonPropertyOrder(1), YamlMember(Alias = "type", Order = 1)]
    public virtual required string Type { get; set; }

    /// <summary>
    /// Gets or sets the thread associated with this event.
    /// </summary>
    [Description("The thread associated with this event.")]
    [Required]
    [DataMember(Name = "thread", Order = 2), JsonPropertyName("thread"), JsonPropertyOrder(2), YamlMember(Alias = "thread", Order = 2)]
    public virtual required IThreadRecord Thread { get; set; }

}