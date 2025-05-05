namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a thread's checkpoint.
/// </summary>
[Description("Represents a thread's checkpoint.")]
[DataContract]
public record ThreadCheckpoint
{

    /// <summary>
    /// Gets or sets the checkpoint's id.
    /// </summary>
    [Description("The checkpoint's id.")]
    [Required, MinLength(1)]
    [DataMember(Name = "checkpoint_id", Order = 1), JsonPropertyName("checkpoint_id"), JsonPropertyOrder(1), YamlMember(Alias = "checkpoint_id", Order = 1)]
    public virtual string Id { get; set; } = null!;

}
