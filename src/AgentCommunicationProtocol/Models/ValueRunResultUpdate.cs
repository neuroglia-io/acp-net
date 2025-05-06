namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a partial run result provided as value through streaming.
/// </summary>
[Description("Represents partial run result provided as value through streaming.")]
[DataContract]
public record ValueRunResultUpdate
    : RunResultUpdate
{

    /// <summary>
    /// Gets or sets the type of the run result update
    /// </summary>
    [Description("The type of the run result update.")]
    [Required, MinLength(1)]
    [DataMember(Name = "type", Order = 1), JsonPropertyName("type"), JsonPropertyOrder(1), YamlMember(Alias = "type", Order = 1)]
    public override string Type => StreamingMode.Values;

    /// <summary>
    /// Gets or sets the run's current state.
    /// </summary>
    [Description("The thread's current state.")]
    [Required]
    [DataMember(Name = "values", Order = 4), JsonPropertyName("values"), JsonPropertyOrder(4), YamlMember(Alias = "values", Order = 4)]
    public virtual EquatableDictionary<string, object> Values { get; set; } = null!;

    /// <summary>
    /// Gets or sets the run's current messages
    /// </summary>
    [Description("The thread's current messages.")]
    [DataMember(Name = "messages", Order = 5), JsonPropertyName("messages"), JsonPropertyOrder(5), YamlMember(Alias = "messages", Order = 5)]
    public virtual EquatableList<Message>? Messages { get; set; }

}
