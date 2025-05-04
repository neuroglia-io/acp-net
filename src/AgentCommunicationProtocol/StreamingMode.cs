namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported streaming modes
/// </summary>
public static class StreamingMode
{

    /// <summary>
    /// Values streaming mode.
    /// </summary>
    public const string Values = "values";
    /// <summary>
    /// Custom object streaming mode.
    /// </summary>
    public const string Custom = "custom";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Values;
        yield return Custom;
    }

}
