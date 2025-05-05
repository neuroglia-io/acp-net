namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported strategies that can be used to address the existence of a thread.
/// </summary>
public static class ThreadIfExistStrategy
{

    /// <summary>
    /// Raises an error if the thread exists.
    /// </summary>
    public const string Raise = "raise";
    /// <summary>
    /// Do nothing if the thread exists.
    /// </summary>
    public const string DoNothing = "do_nothing";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Raise;
        yield return DoNothing;
    }

}
