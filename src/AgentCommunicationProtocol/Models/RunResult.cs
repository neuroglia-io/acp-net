namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the final result of a run.
/// </summary>
[Description("Represents the final result of a run.")]
[DataContract]
public record RunResult
    : RunOutput
{

    /// <summary>
    /// Gets or sets the output type.
    /// </summary>
    [Description("The output type.")]
    [IgnoreDataMember, JsonIgnore, YamlIgnore]
    public override string Type => RunOutputType.Result;

    /// <summary>
    /// Gets or sets the run's output. The schema is described in agent ACP descriptor under 'spec.output'.
    /// </summary>
    [Description("The run's output. The schema is described in agent ACP descriptor under 'spec.output'.")]
    [DataMember(Name = "values", Order = 2), JsonPropertyName("values"), JsonPropertyOrder(2), YamlMember(Alias = "values", Order = 2)]
    public virtual EquatableDictionary<string, object>? Values { get; set; }

    /// <summary>
    /// Gets or sets the messages returned by the run.
    /// </summary>
    [Description("The messages returned by the run.")]
    [DataMember(Name = "messages", Order = 3), JsonPropertyName("messages"), JsonPropertyOrder(3), YamlMember(Alias = "messages", Order = 3)]
    public virtual EquatableList<Message>? Messages { get; set; }

}
