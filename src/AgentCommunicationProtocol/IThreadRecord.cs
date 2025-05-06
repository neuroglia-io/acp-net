namespace AgentCommunicationProtocol;

/// <summary>
/// Defines the fundamentals of a thread record.
/// </summary>
public interface IThreadRecord
{

    /// <summary>
    /// Gets the thread's unique identifier.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the date and time the thread was created at.
    /// </summary>
    DateTimeOffset CreatedAt { get; }

    /// <summary>
    /// Gets the date and time the thread was last updated at.
    /// </summary>
    DateTimeOffset UpdatedAt { get; }

    /// <summary>
    /// Gets the thread's metadata, if any.
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }

    /// <summary>
    /// Gets the thread's status.
    /// </summary>
    string Status { get; }

    /// <summary>
    /// Gets the thread's current state.
    /// </summary>
    IReadOnlyDictionary<string, object>? Values { get; }

    /// <summary>
    /// Gets the thread's current messages. If messages are contained in 'values', implementations should remove them from values when returning messages. When this key isn't present it means the thread doesn't support messages.
    /// </summary>
    IReadOnlyList<Message>? Messages { get; }

    /// <summary>
    /// Gets the thread's current checkpoint.
    /// </summary>
    ThreadCheckpoint Checkpoint { get; }

    /// <summary>
    /// Gets the <see cref="IThreadRecord"/>'s <see cref="ThreadState"/>
    /// </summary>
    /// <returns>A new <see cref="ThreadState"/></returns>
    Models.ThreadState GetState() => new()
    {
        Checkpoint = Checkpoint,
        Metadata = Metadata == null ? null : new(Metadata),
        Values = Values == null ? [] : new(Values),
        Messages = Messages == null ? null : new(Messages)
    };

    /// <summary>
    /// Converts the <see cref="IThreadRecord"/> into a new <see cref="Thread"/>
    /// </summary>
    /// <returns>A new <see cref="Thread"/></returns>
    Models.Thread AsThread() => new()
    {
        Id = Id,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt,
        Status = Status,
        Metadata = Metadata == null ? null : new(Metadata),
        Values = Values == null ? null : new(Values),
        Messages = Messages == null ? null : new(Messages)
    };

}
