namespace AgentCommunicationProtocol.Queries.Agents;

/// <summary>
/// Represents the query used to search for agents.
/// </summary>
[Description("Represents the query used to search for agents.")]
[DataContract]
public class SearchAgentsQuery
    : Query<IEnumerable<Agent>>
{

    /// <summary>
    /// Gets the minimum amount of agents that can be returned by a search query.
    /// </summary>
    public const int MinimumLimit = 1;
    /// <summary>
    /// Gets the maximum amount of agents that can be returned by a search query.
    /// </summary>
    public const int MaximumLimit = 1000;
    /// <summary>
    /// Gets the default amount of agents returned by a search query.
    /// </summary>
    public const int DefaultLimit = 10;

    /// <summary>
    /// Gets/sets the name, if any, of the agents to match.
    /// </summary>
    [Description("The name, if any, of the agents to match.")]
    [DataMember(Name = "name", Order = 1), JsonPropertyName("name"), JsonPropertyOrder(1), YamlMember(Alias = "name", Order = 1)]
    public virtual string? Name { get; set; }

    /// <summary>
    /// Gets/sets the version, if any, of the agents to match.
    /// </summary>
    [Description("The version, if any, of the agents to match.")]
    [DataMember(Name = "version", Order = 2), JsonPropertyName("version"), JsonPropertyOrder(2), YamlMember(Alias = "version", Order = 2)]
    public virtual string? Version { get; set; }

    /// <summary>
    /// Gets/sets the maximum number of agents to return. Defaults to '10'.
    /// </summary>
    [Description("The maximum number of agents to return. Defaults to '10'.")]
    [Range(MinimumLimit, MaximumLimit)]
    [DataMember(Name = "limit", Order = 3), JsonPropertyName("limit"), JsonPropertyOrder(3), YamlMember(Alias = "limit", Order = 3)]
    public virtual uint Limit { get; set; } = DefaultLimit;

    /// <summary>
    /// Gets/sets the offset to start listing agents from. Defaults to '0'.
    /// </summary>
    [Description("The offset to start listing agents from. Defaults to '0'.")]
    [DataMember(Name = "offset", Order = 4), JsonPropertyName("offset"), JsonPropertyOrder(4), YamlMember(Alias = "offset", Order = 4)]
    public virtual uint Offset { get; set; }

}
