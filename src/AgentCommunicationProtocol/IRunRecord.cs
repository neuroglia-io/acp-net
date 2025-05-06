namespace AgentCommunicationProtocol;

/// <summary>
/// Defines the fundamentals of a run record.
/// </summary>
public interface IRunRecord
{

    /// <summary>
    /// Gets the run's unique identifier.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the unique identifier of the thread, if any, the run belongs to.
    /// </summary>
    string? ThreadId { get; }

    /// <summary>
    /// Gets the unique identifier of the agent the run concerns.
    /// </summary>
    string AgentId { get; }

    /// <summary>
    /// Gets the date and time the run was created at.
    /// </summary>
    DateTimeOffset CreatedAt { get; }

    /// <summary>
    /// Gets the date and time the run was last updated at.
    /// </summary>
    DateTimeOffset UpdatedAt { get; }

    /// <summary>
    /// Gets the run's status.
    /// </summary>
    string Status { get; }

    /// <summary>
    /// Gets the run's output.
    /// </summary>
    RunOutput? Output { get; }

    /// <summary>
    /// Converts the record into a new <see cref="Run"/>.
    /// </summary>
    /// <returns>A new <see cref="Run"/>.</returns>
    Run AsRun();

}

/// <summary>
/// Defines the fundamentals of a run record.
/// </summary>
/// <typeparam name="TRun">The type of recorded run.</typeparam>
public interface IRunRecord<TRun>
    : IRunRecord
    where TRun : Run
{

    /// <summary>
    /// Converts the record into a new <see cref="Run"/>.
    /// </summary>
    /// <returns>A new <see cref="Run"/>.</returns>
    new TRun AsRun();

}
