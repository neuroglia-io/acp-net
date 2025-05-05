namespace AgentCommunicationProtocol.Commands.Runs;

/// <summary>
/// Represents the command used to create a new stateful run.
/// </summary>
[Description("Represents the command used to create a new run.")]
[DataContract]
public class CreateStatefulRunCommand
    : Command
{

    /// <summary>
    /// Gets/sets the unique identifier of the agent to run. If not provided will use the default agent for this service.
    /// </summary>
    [Description("The unique identifier of the agent to run. If not provided will use the default agent for this service.")]
    [DataMember(Name = "agent_id", Order = 1), JsonPropertyName("agent_id"), JsonPropertyOrder(1), YamlMember(Alias = "agent_id", Order = 1)]
    public virtual string? AgentId { get; set; }

    /// <summary>
    /// Gets/sets the agent's input. The schema is described in agent ACP descriptor under 'spec.thread_state.input'.
    /// </summary>
    [Description("The agent's input. The schema is described in agent ACP descriptor under 'spec.thread_state.input'.")]
    [DataMember(Name = "input", Order = 2), JsonPropertyName("input"), JsonPropertyOrder(2), YamlMember(Alias = "input", Order = 2)]
    public virtual EquatableDictionary<string, object>? Input { get; set; }

    /// <summary>
    /// Gets/sets a key/value mapping of the run's metadata, if any.
    /// </summary>
    [Description("A key/value mapping of the run's metadata, if any.")]
    [DataMember(Name = "metadata", Order = 3), JsonPropertyName("metadata"), JsonPropertyOrder(3), YamlMember(Alias = "metadata", Order = 3)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; }

    /// <summary>
    /// Gets/sets an object used to configure the agent to run.
    /// </summary>
    [Description("An object used to configure the agent to run.")]
    [DataMember(Name = "config", Order = 4), JsonPropertyName("config"), JsonPropertyOrder(4), YamlMember(Alias = "config", Order = 4)]
    public virtual AgentRunConfiguration? Config { get; set; }

    /// <summary>
    /// Gets/sets the uri of the webhook to call, if any, upon change of run status. This is a url that accepts a POST containing the Run object as body.
    /// </summary>
    [Description("The uri of the webhook to call, if any, upon change of run status. This is a url that accepts a POST containing the Run object as body.")]
    [DataMember(Name = "webhook", Order = 5), JsonPropertyName("webhook"), JsonPropertyOrder(5), YamlMember(Alias = "webhook", Order = 5)]
    public virtual Uri? Webhook { get; set; }

    /// <summary>
    /// Gets/sets the streaming modes to use, if any.
    /// </summary>
    [Description("The streaming modes to use, if any.")]
    [AllowedValues(StreamingMode.Values, StreamingMode.Custom)]
    [DataMember(Name = "stream_mode", Order = 6), JsonPropertyName("stream_mode"), JsonPropertyOrder(6), YamlMember(Alias = "stream_mode", Order = 6)]
    public virtual EquatableList<string>? StreamMode { get; set; }

    /// <summary>
    /// Gets/sets the disconnect mode to use. Defaults to 'cancel'.
    /// </summary>
    [Description("The disconnect mode to use. Defaults to 'cancel'.")]
    [AllowedValues(RunDisconnectMode.Cancel, RunDisconnectMode.Continue), DefaultValue(RunDisconnectMode.Cancel)]
    [DataMember(Name = "on_disconnect", Order = 7), JsonPropertyName("on_disconnect"), JsonPropertyOrder(7), YamlMember(Alias = "on_disconnect", Order = 7)]
    public virtual string OnDisconnect { get; set; } = RunDisconnectMode.Cancel;

    /// <summary>
    /// Gets/sets the multitask strategy to use. Defaults to 'reject'.
    /// </summary>
    [Description("The multitask strategy to use. Defaults to 'reject'.")]
    [AllowedValues(RunMultitaskStrategy.Reject, RunMultitaskStrategy.Rollback, RunMultitaskStrategy.Rollback, RunMultitaskStrategy.Enqueue), DefaultValue(RunMultitaskStrategy.Reject)]
    [DataMember(Name = "multitask_strategy", Order = 8), JsonPropertyName("multitask_strategy"), JsonPropertyOrder(8), YamlMember(Alias = "multitask_strategy", Order = 8)]
    public virtual string MultitaskStrategy { get; set; } = RunMultitaskStrategy.Reject;

    /// <summary>
    /// Gets/sets the number of seconds, if any, to wait before starting the run. Use to schedule future runs.
    /// </summary>
    [Description("The number of seconds, if any, to wait before starting the run. Use to schedule future runs.")]
    [DataMember(Name = "after_seconds", Order = 9), JsonPropertyName("after_seconds"), JsonPropertyOrder(9), YamlMember(Alias = "after_seconds", Order = 9)]
    public virtual uint AfterSeconds { get; set; }

    /// <summary>
    /// Gets/sets a boolean indicating whether to stream output from subgraphs. Defaults to 'false'.
    /// </summary>
    [Description("A boolean indicating whether to stream output from subgraphs. Defaults to 'false'.")]
    [DefaultValue(false)]
    [DataMember(Name = "stream_subgraphs", Order = 10), JsonPropertyName("stream_subgraphs"), JsonPropertyOrder(10), YamlMember(Alias = "stream_subgraphs", Order = 10)]
    public virtual bool StreamSubgraphs { get; set; }

    /// <summary>
    /// Gets/sets the strategy used to handle missing thread. Defaults to 'reject'.
    /// </summary>
    [Description("The strategy used to handle missing thread.")]
    [AllowedValues(RunIfNotExistStrategy.Reject, RunIfNotExistStrategy.Create), DefaultValue(RunIfNotExistStrategy.Reject)]
    [DataMember(Name = "if_not_exists", Order = 11), JsonPropertyName("if_not_exists"), JsonPropertyOrder(11), YamlMember(Alias = "if_not_exists", Order = 11)]
    public virtual string IfNotExists { get; set; } = RunIfNotExistStrategy.Reject;

}