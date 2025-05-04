namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an object used to configure an agent's run.
/// </summary>
[Description("Represents an object used to configure an agent's run.")]
public record AgentRunConfiguration
{

    /// <summary>
    /// Gets/sets a list containing the tags, if any, to associated to the run.
    /// </summary>
    [Description("A list containing the tags, if any, to associated to the run.")]
    [DataMember(Name = "tags", Order = 1), JsonPropertyName("tags"), JsonPropertyOrder(1), YamlMember(Alias = "tags", Order = 1)]
    public virtual EquatableList<string>? Tags { get; set; }

    /// <summary>
    /// Gets/sets the recursion limit, if any.
    /// </summary>
    [Description("The recursion limit, if any.")]
    [DataMember(Name = "recursion_limit", Order = 2), JsonPropertyName("recursion_limit"), JsonPropertyOrder(2), YamlMember(Alias = "recursion_limit", Order = 2)]
    public virtual uint? RecursionLimit { get; set; }

    /// <summary>
    /// Gets/sets a key/value mapping of the agent's configuration properties, if any, as defined by the agent's 'spec.config'. If missing, default values are used.
    /// </summary>
    [Description("A key/value mapping of the agent's configuration properties, if any, as defined by the agent's 'spec.config'. If missing, default values are used.")]
    [DataMember(Name = "configurable", Order = 3), JsonPropertyName("configurable"), JsonPropertyOrder(3), YamlMember(Alias = "configurable", Order = 3)]
    public virtual EquatableDictionary<string, object>? Properties { get; set; }

}