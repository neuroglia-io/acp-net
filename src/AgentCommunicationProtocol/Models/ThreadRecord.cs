namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a thread's record.
/// </summary>
[Description("Represents a thread's record.")]
[DataContract]
public record ThreadRecord
    : IThreadRecord
{

    /// <summary>
    /// Gets or sets the thread's unique identifier.
    /// </summary>
    [Description("The thread's unique identifier.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time the thread was created at.
    /// </summary>
    [Description("The date and time the thread was created at.")]
    [Required]
    [DataMember(Name = "created_at", Order = 2), JsonPropertyName("created_at"), JsonPropertyOrder(2), YamlMember(Alias = "created_at", Order = 2)]
    public virtual required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time the thread was last updated at.
    /// </summary>
    [Description("The date and time the thread was last updated at.")]
    [Required]
    [DataMember(Name = "updated_at", Order = 3), JsonPropertyName("updated_at"), JsonPropertyOrder(3), YamlMember(Alias = "updated_at", Order = 3)]
    public virtual required DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the thread's metadata, if any.
    /// </summary>
    [Description("The thread's metadata, if any.")]
    [DataMember(Name = "metadata", Order = 4), JsonPropertyName("metadata"), JsonPropertyOrder(4), YamlMember(Alias = "metadata", Order = 4)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; }

    /// <summary>
    /// Gets or sets the thread's status.
    /// </summary>
    [Description("The thread's status.")]
    [Required, AllowedValues(ThreadStatus.Idle, ThreadStatus.Busy, ThreadStatus.Interrupted, ThreadStatus.Error)]
    [DataMember(Name = "status", Order = 5), JsonPropertyName("status"), JsonPropertyOrder(5), YamlMember(Alias = "status", Order = 5)]
    public virtual string Status { get; set; } = ThreadStatus.Idle;

    /// <summary>
    /// Gets or sets the thread's current state.
    /// </summary>
    [Description("The thread's current state.")]
    [DataMember(Name = "values", Order = 6), JsonPropertyName("values"), JsonPropertyOrder(6), YamlMember(Alias = "values", Order = 6)]
    public virtual EquatableDictionary<string, object>? Values { get; set; }

    /// <summary>
    /// Gets or sets the thread's current messages. If messages are contained in 'values', implementations should remove them from values when returning messages. When this key isn't present it means the thread doesn't support messages.
    /// </summary>
    [Description("The thread's current messages. If messages are contained in 'values', implementations should remove them from values when returning messages. When this key isn't present it means the thread doesn't support messages.")]
    [DataMember(Name = "messages", Order = 7), JsonPropertyName("messages"), JsonPropertyOrder(7), YamlMember(Alias = "messages", Order = 7)]
    public virtual EquatableList<Message>? Messages { get; set; }

    /// <summary>
    /// Gets or set the thread's current checkpoint.
    /// </summary>
    [Description("The thread's current checkpoint.")]
    [Required]
    [DataMember(Name = "checkpoint", Order = 8), JsonPropertyName("checkpoint"), JsonPropertyOrder(8), YamlMember(Alias = "checkpoint", Order = 8)]
    public virtual required ThreadCheckpoint Checkpoint { get; set; } = null!;

    IReadOnlyDictionary<string, object>? IThreadRecord.Metadata => Metadata?.AsReadOnly();

    IReadOnlyDictionary<string, object>? IThreadRecord.Values => Values?.AsReadOnly();

    IReadOnlyList<Message>? IThreadRecord.Messages => Messages?.AsReadOnly();


}