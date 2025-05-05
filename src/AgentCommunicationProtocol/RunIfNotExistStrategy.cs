namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported strategies that can be used to address the non-existence of a run.
/// </summary>
public static class RunIfNotExistStrategy
{

    /// <summary>
    /// Raises an error if the run is missing.
    /// </summary>
    public const string Reject = "reject";
    /// <summary>
    /// Creates a new run.
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
