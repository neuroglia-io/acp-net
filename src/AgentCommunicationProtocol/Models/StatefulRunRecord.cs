namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an object used to record a stateful agent run.
/// </summary>
[Description("Represents an object used to record a stateful agent's run.")]
[DataContract]
public record StatefulRunRecord
    : RunRecord<StatefulRun>, IStatefulRunRecord
{

    /// <summary>
    /// Gets or sets the options that were used to create this run.
    /// </summary>
    [Description("The options that were used to create this run.")]
    [Required]
    [DataMember(Name = "creation", Order = 8), JsonPropertyName("creation"), JsonPropertyOrder(8), YamlMember(Alias = "creation", Order = 8)]
    public virtual required StatefulRunCreationOptions Creation { get; set; } = null!;

    /// <inheritdoc/>
    public override StatefulRun AsRun() => new()
    {
        Id = Id,
        ThreadId = ThreadId,
        AgentId = AgentId,
        CreatedAt = CreatedAt,
        UpdatedAt = UpdatedAt,
        Status = Status,
        Creation = Creation
    };

}
