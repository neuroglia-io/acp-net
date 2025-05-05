namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the state of a thread.
/// </summary>
[Description("Represents the state of a thread.")]
[DataContract]
public record ThreadState
{

    /// <summary>
    /// Gets or set the thread's current checkpoint.
    /// </summary>
    [Description("The thread's current checkpoint.")]
    [Required]
    [DataMember(Name = "checkpoint", Order = 1), JsonPropertyName("checkpoint"), JsonPropertyOrder(1), YamlMember(Alias = "checkpoint", Order = 1)]
    public virtual ThreadCheckpoint Checkpoint { get; set; } = null!;

    /// <summary>
    /// Gets or sets the thread's current state.
    /// </summary>
    [Description("The thread's current state.")]
    [Required]
    [DataMember(Name = "values", Order = 2), JsonPropertyName("values"), JsonPropertyOrder(2), YamlMember(Alias = "values", Order = 2)]
    public virtual EquatableDictionary<string, object> Values { get; set; } = null!;

    /// <summary>
    /// Gets or sets a list containing the thread's current messages. If messages are contained in 'values', implementations should remove them from values when returning messages. When this key isn't present it means the thread/agent doesn't support messages.
    /// </summary>
    [Description("A list containing the thread's current messages. If messages are contained in 'values', implementations should remove them from values when returning messages. When this key isn't present it means the thread/agent doesn't support messages.")]
    [Required]
    [DataMember(Name = "messages", Order = 3), JsonPropertyName("messages"), JsonPropertyOrder(3), YamlMember(Alias = "messages", Order = 3)]
    public virtual EquatableList<Message>? Messages { get; set; }

    /// <summary>
    /// Gets or sets a key/value mapping of the metadata properties, if any, associated to the thread.
    /// </summary>
    [Description("A key/value mapping of the metadata properties, if any, associated to the thread.")]
    [Required]
    [DataMember(Name = "metadata", Order = 4), JsonPropertyName("metadata"), JsonPropertyOrder(4), YamlMember(Alias = "metadata", Order = 4)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; }

}
