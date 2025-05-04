namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all the possible statuses of a run.
/// </summary>
public static class RunStatus
{

    /// <summary>
    /// Indicates that the run is pending execution.
    /// </summary>
    public const string Pending = "pending";
    /// <summary>
    /// Indicates that an error has been encountered while executing the run.
    /// </summary>
    public const string Error = "error";
    /// <summary>
    /// Indicates that the run was successfully executed.
    /// </summary>
    public const string Success = "success";
    /// <summary>
    /// Indicates that the run has timed out.
    /// </summary>
    public const string Timeout = "timeout";
    /// <summary>
    /// Indicates that the run has been interrupted and is pending to be resumed.
    /// </summary>
    public const string Interrupted = "interrupted";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Pending;
        yield return Error;
        yield return Success;
        yield return Timeout;
        yield return Interrupted;
    }

}
