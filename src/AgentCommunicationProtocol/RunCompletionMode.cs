namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported run completion modes
/// </summary>
public static class RunCompletionMode
{

    /// <summary>
    /// Delete upon completion.
    /// </summary>
    public const string Delete = "delete";
    /// <summary>
    /// Keep upon completion.
    /// </summary>
    public const string Keep = "keep";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Delete;
        yield return Keep;
    }

}
