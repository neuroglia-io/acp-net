namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all supported run disconnect modes
/// </summary>
public static class RunDisconnectMode
{

    /// <summary>
    /// Cancel upon disconnection.
    /// </summary>
    public const string Cancel = "cancel";
    /// <summary>
    /// Continue upon disconnection.
    /// </summary>
    public const string Continue = "continue";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Cancel;
        yield return Continue;
    }

}
