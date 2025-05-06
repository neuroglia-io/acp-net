namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Represents an interrupt request emitted by an agent during run execution.
/// Used to signal that the agent requires external input (e.g., approval, clarification)
/// before it can continue processing.
/// </summary>
public class InterruptRequest
{

    /// <summary>
    /// Gets the ID of the run that triggered the interrupt.
    /// </summary>
    public required string RunId { get; init; }

    /// <summary>
    /// Gets the type of interrupt requested (e.g., 'approval', 'question').
    /// </summary>
    public required string Type { get; init; }

    /// <summary>
    /// Gets the payload associated with the interrupt request. The payload represents the content of the interrupt and may vary depending on the interrupt type.
    /// </summary>
    public required object Payload { get; init; }

    /// <summary>
    /// Gets optional metadata associated with the interrupt request.
    /// This may include payloads needed to resolve or fulfill the interrupt.
    /// </summary>
    public IDictionary<string, object>? Metadata { get; init; }

}
