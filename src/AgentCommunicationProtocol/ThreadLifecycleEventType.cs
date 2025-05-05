namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all types of thread lifecycle events
/// </summary>
public static class ThreadLifecycleEventType
{

    /// <summary>
    /// Indicates that a new thread has been created.
    /// </summary>
    public const string Created = "created";
    /// <summary>
    /// Indicates that the state of a thread has been patched.
    /// </summary>
    public const string Patched = "patched";
    /// <summary>
    /// Indicates that a thread has been deleted.
    /// </summary>
    public const string Deleted = "deleted";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Created;
        yield return Patched;
        yield return Deleted;
    }

}