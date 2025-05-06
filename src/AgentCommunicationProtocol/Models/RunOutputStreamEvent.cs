namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a server-sent event (SSE) containing an agent output event.
/// </summary>
[Description("Represents a server-sent event (SSE) containing an agent output event.")]
[DataContract]
public record RunOutputStreamEvent
{

    /// <summary>
    /// Gets or sets the unique identifier of the event.
    /// </summary>
    [Description("The unique identifier of the event.")]
    [Required, MinLength(1)]
    [DataMember(Name = "id", Order = 1), JsonPropertyName("id"), JsonPropertyOrder(1), YamlMember(Alias = "id", Order = 1)]
    public virtual required string Id { get; set; }

    /// <summary>
    /// Gets or sets the event type. This is the constant string agent_event to be compatible with SSE spec. The actual type differentiation is done in the event itself.
    /// </summary>
    [Description("The event type. This is the constant string agent_event to be compatible with SSE spec. The actual type differentiation is done in the event itself.")]
    [Required, MinLength(1)]
    [DataMember(Name = "event", Order = 2), JsonPropertyName("event"), JsonPropertyOrder(2), YamlMember(Alias = "event", Order = 2)]
    public virtual string Event { get; set; } = "agent_event";

    /// <summary>
    /// Gets or sets the data structure carried in the SSE event data field. The event can carry either a full 'ValueRunResultUpdate', if streaming mode is 'values' or an 'CustomRunResultUpdate' if streaming mode is 'custom'.
    /// </summary>
    [Description("Gets or sets the data structure carried in the SSE event data field. The event can carry either a full 'ValueRunResultUpdate', if streaming mode is 'values' or an 'CustomRunResultUpdate' if streaming mode is 'custom'.")]
    [Required, MinLength(1)]
    [DataMember(Name = "data", Order = 3), JsonPropertyName("data"), JsonPropertyOrder(3), YamlMember(Alias = "data", Order = 3)]
    public virtual required RunResultUpdate Data { get; set; }

}
