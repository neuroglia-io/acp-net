namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the declaration of the invocation features an agent is capable of.
/// </summary>
[Description("Represents the declaration of the invocation features an agent is capable of.")]
[DataContract]
public record AgentCapabilities
{

    /// <summary>
    /// Gets or sets a boolean indicating whether the agent supports run threads. Defaults to false.
    /// </summary>
    [Description("A boolean indicating whether the agent supports run threads. Defaults to false.")]
    [DefaultValue(false)]
    [DataMember(Name = "threads", Order = 1), JsonPropertyName("threads"), JsonPropertyOrder(1), YamlMember(Alias = "threads", Order = 1)]
    public virtual bool Threads { get; set; }

    /// <summary>
    /// Gets or sets a boolean indicating whether the agent runs can interrupt to request additional input and can be subsequently resumed.
    /// </summary>
    [Description("A boolean indicating whether the agent runs can interrupt to request additional input and can be subsequently resumed. Defaults to false.")]
    [DefaultValue(false)]
    [DataMember(Name = "interrupts", Order = 2), JsonPropertyName("interrupts"), JsonPropertyOrder(2), YamlMember(Alias = "interrupts", Order = 2)]
    public virtual bool Interrupts { get; set; }

    /// <summary>
    /// Gets or sets a boolean indicating whether the agent supports a webhook to report run results.
    /// </summary>
    [Description("A boolean indicating whether the agent supports a webhook to report run results. Defaults to false.")]
    [DefaultValue(false)]
    [DataMember(Name = "callbacks", Order = 3), JsonPropertyName("callbacks"), JsonPropertyOrder(3), YamlMember(Alias = "callbacks", Order = 3)]
    public virtual bool Callbacks { get; set; }

    /// <summary>
    /// Gets or sets the streaming modes, if any, supported by the agent.
    /// </summary>
    [Description("The streaming modes, if any, supported by the agent.")]
    [DataMember(Name = "streaming", Order = 4), JsonPropertyName("streaming"), JsonPropertyOrder(4), YamlMember(Alias = "streaming", Order = 4)]
    public virtual StreamingModes? Streaming { get; set; }

}
