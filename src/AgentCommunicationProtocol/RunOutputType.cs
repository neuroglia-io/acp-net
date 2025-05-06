namespace AgentCommunicationProtocol;

/// <summary>
/// Enumerates all the possible types of run outputs.
/// </summary>
public static class RunOutputType
{

    /// <summary>
    /// Indicates a standard result.
    /// </summary>
    public const string Result = "result";
    /// <summary>
    /// Indicates an interrupt.
    /// </summary>
    public const string Interrupt = "interrupt";
    /// <summary>
    /// Indicates an error.
    /// </summary>
    public const string Error = "error";

    /// <summary>
    /// Gets all supported values.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<string> AsEnumerable()
    {
        yield return Result;
        yield return Interrupt;
        yield return Error;
    }

}