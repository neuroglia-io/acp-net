namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported run multitask strategies
/// </summary>
public static class RunMultitaskStrategy
{

    /// <summary>
    /// Rejects multitasks.
    /// </summary>
    public const string Reject = "reject";
    /// <summary>
    /// Rolls back upon multitasks.
    /// </summary>
    public const string Rollback = "rollback";
    /// <summary>
    /// Interrupts upon multitasks.
    /// </summary>
    public const string Interrupt = "interrupt";
    /// <summary>
    /// Enqueues additional tasks.
    /// </summary>
    public const string Enqueue = "enqueue";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Reject;
        yield return Rollback;
        yield return Interrupt;
        yield return Enqueue;
    }

}