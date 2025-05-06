namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the options used to create a new stateful run.
/// </summary>
[Description("Represents the options used to create a new stateful run.")]
[DataContract]
public record StatefulRunCreationOptions
    : RunCreationOptions
{

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
