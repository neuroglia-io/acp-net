namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all the possible statuses of a thread.
/// </summary>
public static class ThreadStatus
{

    /// <summary>
    /// Indicates that the thread is idle.
    /// </summary>
    public const string Idle = "idle";
    /// <summary>
    /// Indicates that the thread is busy.
    /// </summary>
    public const string Busy = "busy";
    /// <summary>
    /// Indicates that the thread has been interrupted and is pending to be resumed.
    /// </summary>
    public const string Interrupted = "interrupted";
    /// <summary>
    /// Indicates that an error has been encountered while executing the thread.
    /// </summary>
    public const string Error = "error";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Idle;
        yield return Busy;
        yield return Interrupted;
        yield return Error;
    }

}