namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the specification of an agent's capabilities, config, input, output, and interrupts.
/// </summary>
[Description("Represents the specification of an agent's capabilities, config, input, output, and interrupts.")]
[DataContract]
public record AgentSpecs
{

    /// <summary>
    /// Gets or sets the declaration of the invocation features the agent is capable of.
    /// </summary>
    [Description("The declaration of the invocation features the agent is capable of.")]
    [Required]
    [DataMember(Name = "capabilities", Order = 1), JsonPropertyName("capabilities"), JsonPropertyOrder(1), YamlMember(Alias = "capabilities", Order = 1)]
    public virtual AgentCapabilities Capabilities { get; set; } = null!;

    /// <summary>
    /// Gets or sets a JSON schema used to describe the agent's input.
    /// </summary>
    [Description("A JSON schema used to describe the agent's input.")]
    [Required]
    [DataMember(Name = "input", Order = 2), JsonPropertyName("input"), JsonPropertyOrder(2), YamlMember(Alias = "input", Order = 2)]
    public virtual JsonSchema Input { get; set; } = null!;

    /// <summary>
    /// Gets or sets a JSON schema used to describe the agent's output.
    /// </summary>
    [Description("A JSON schema used to describe the agent's output.")]
    [Required]
    [DataMember(Name = "output", Order = 3), JsonPropertyName("output"), JsonPropertyOrder(3), YamlMember(Alias = "output", Order = 3)]
    public virtual JsonSchema Output { get; set; } = null!;

    /// <summary>
    /// Gets or sets JSON schema used to describe the agent's custom streaming update, if any. Must be specified if streaming.custom capability is true, otherwise ignored.
    /// </summary>
    [Description("A JSON schema used to describe the agent's custom streaming update, if any. Must be specified if streaming.custom capability is true, otherwise ignored.")]
    [DataMember(Name = "custom_streaming_update", Order = 4), JsonPropertyName("custom_streaming_update"), JsonPropertyOrder(4), YamlMember(Alias = "custom_streaming_update", Order = 4)]
    public virtual JsonSchema? CustomStreamingUpdate { get; set; }

    /// <summary>
    /// Gets or sets JSON schema used to describe the format of the agent's ThreadState. Cannot be specified if agent's threads capability is false. If not specified, when the agent's threads capability is true, then the API to retrieve the agent's ThreadState from a Thread or a Run is not available.
    /// </summary>
    [Description("A JSON schema used to describe the format of the agent's ThreadState. Cannot be specified if agent's threads capability is false. If not specified, when the agent's threads capability is true, then the API to retrieve the agent's ThreadState from a Thread or a Run is not available.")]
    [DataMember(Name = "thread_state", Order = 5), JsonPropertyName("thread_state"), JsonPropertyOrder(5), YamlMember(Alias = "thread_state", Order = 5)]
    public virtual JsonSchema? ThreadState { get; set; }

    /// <summary>
    /// Gets or sets JSON schema used to describe the object, if any, used to configure the agent.
    /// </summary>
    [Description("A JSON schema used to describe the object, if any, used to configure the agent.")]
    [DataMember(Name = "config", Order = 6), JsonPropertyName("config"), JsonPropertyOrder(6), YamlMember(Alias = "config", Order = 6)]
    public virtual JsonSchema? Config { get; set; }

    /// <summary>
    /// Gets or sets a list of possible interrupts, if any, that can be provided by the agent. If the agent's interrupts capability is true, this needs to have at least one item.
    /// </summary>
    [Description("A list of possible interrupts, if any, that can be provided by the agent. If the agent's interrupts capability is true, this needs to have at least one item.")]
    [DataMember(Name = "interrupts", Order = 7), JsonPropertyName("interrupts"), JsonPropertyOrder(7), YamlMember(Alias = "interrupts", Order = 7)]
    public virtual EquatableList<Interrupt>? Interrupts { get; set; }

}
