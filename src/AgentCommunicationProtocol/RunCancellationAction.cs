namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all possible cancellation actions.
/// </summary>
public static class RunCancellationAction
{

    /// <summary>
    /// Indicates that the run must be simply cancelled.
    /// </summary>
    public const string Interrupt = "interrupt";
    /// <summary>
    /// Indicates that the run must be cancelled and that associated checkpoints should be deleted.
    /// </summary>
    public const string Rollback = "rollback";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Interrupt;
        yield return Rollback;
    }

}