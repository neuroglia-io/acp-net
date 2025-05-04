namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an object used to describe an agent's stateless run.
/// </summary>
[Description("Represents an object used to describe an agent's stateless run.")]
[DataContract]
public record AgentStatelessRun
    : AgentRun
{

    /// <summary>
    /// Gets or sets the parameters used to create the run.
    /// </summary>
    [Description("The rparameters used to create the run.")]
    [Required]
    [DataMember(Name = "creation", Order = 6), JsonPropertyName("creation"), JsonPropertyOrder(6), YamlMember(Alias = "creation", Order = 6)]
    public virtual AgentStatelelessRunParameters Creation { get; set; } = null!;

}
