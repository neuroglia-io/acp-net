namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the output of a run.
/// </summary>
[Description("Represents the output of a run.")]
[DataContract, KnownType(typeof(RunResult)), KnownType(typeof(RunInterrupt)), KnownType(typeof(RunError))]
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(RunResult), RunOutputType.Result), JsonDerivedType(typeof(RunInterrupt), RunOutputType.Interrupt), JsonDerivedType(typeof(RunError), RunOutputType.Error)]
public abstract record RunOutput
{

    /// <summary>
    /// Gets or sets the output type.
    /// </summary>
    public abstract string Type { get; }

}
