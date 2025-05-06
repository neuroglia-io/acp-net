namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an object used to describe a stateful agent run.
/// </summary>
[Description("Represents an object used to describe a stateful agent's run.")]
[DataContract]
public record StatefulRun
    : Run
{

    /// <summary>
    /// Gets or sets the options that were used to create this run.
    /// </summary>
    [Description("The options that were used to create this run.")]
    [Required]
    [DataMember(Name = "creation", Order = 7), JsonPropertyName("creation"), JsonPropertyOrder(7), YamlMember(Alias = "creation", Order = 7)]
    public virtual required StatefulRunCreationOptions Creation { get; set; } = null!;

}
