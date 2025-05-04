namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported completion modes
/// </summary>
public static class RunIfNotExistStrategy
{

    /// <summary>
    /// Raises an error if the thread is missing.
    /// </summary>
    public const string Reject = "reject";
    /// <summary>
    /// Creates a new thread.
    /// </summary>
    public const string Create = "create";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Reject;
        yield return Create;
    }

}