namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the parameters used to create a new agent stateless run.
/// </summary>
[Description("Represents the parameters used to create a new agent stateless run.")]
public record AgentStatefulRunParameters
    : AgentRunParameters
{

    /// <summary>
    /// Gets/sets a boolean indicating whether to stream output from subgraphs. Defaults to 'false'.
    /// </summary>
    [Description("A boolean indicating whether to stream output from subgraphs. Defaults to 'false'.")]
    [DefaultValue(false)]
    [DataMember(Name = "stream_subgraphs", Order = 10), JsonPropertyName("stream_subgraphs"), JsonPropertyOrder(10), YamlMember(Alias = "stream_subgraphs", Order = 10)]
    public virtual bool OnCompletion { get; set; }

    /// <summary>
    /// Gets/sets the strategy used to handle missing thread. Defaults to 'reject'.
    /// </summary>
    [Description("The strategy used to handle missing thread.")]
    [AllowedValues(RunIfNotExistStrategy.Reject, RunIfNotExistStrategy.Create), DefaultValue(RunIfNotExistStrategy.Reject)]
    [DataMember(Name = "if_not_exists", Order = 11), JsonPropertyName("if_not_exists"), JsonPropertyOrder(11), YamlMember(Alias = "if_not_exists", Order = 11)]
    public virtual string IfNotExists { get; set; } = RunIfNotExistStrategy.Reject;

}
