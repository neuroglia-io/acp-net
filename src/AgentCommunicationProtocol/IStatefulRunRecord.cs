namespace AgentCommunicationProtocol;

/// <summary>
/// Defines the fundamentals of a stateful run record.
/// </summary>
public interface IStatefulRunRecord
    : IRunRecord<StatefulRun>
{

    /// <summary>
    /// Gets the options that were used to create this run.
    /// </summary>
    StatefulRunCreationOptions Creation { get; }

}
