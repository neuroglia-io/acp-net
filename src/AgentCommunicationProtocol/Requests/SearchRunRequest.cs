namespace AgentCommunicationProtocol.Requests;

/// <summary>
/// Represents the request used to search for runs.
/// </summary>
[Description("Represents the request used to search for runs.")]
[DataContract]
public record SearchRunRequest
{

    /// <summary>
    /// Gets the minium amount of runs that can be returned by a search request.
    /// </summary>
    public const int MinimumLimit = 1;
    /// <summary>
    /// Gets the maximum amount of runs that can be returned by a search request.
    /// </summary>
    public const int MaximumLimit = 1000;
    /// <summary>
    /// Gets the default amount of runs returned by a search request.
    /// </summary>
    public const int DefaultLimit = 10;

    /// <summary>
    /// Gets/sets the unique identifier of the agent, if any, the runs to match belong to.
    /// </summary>
    [Description("The unique identifier of the agent, if any, the runs to match belong to.")]
    [DataMember(Name = "agent_id", Order = 1), JsonPropertyName("agent_id"), JsonPropertyOrder(1), YamlMember(Alias = "agent_id", Order = 1)]
    public virtual string? AgentId { get; set; }

    /// <summary>
    /// Gets/sets the status, if any, to filter runs by.
    /// </summary>
    [Description("The status, if any, to filter runs by.")]
    [AllowedValues(RunStatus.Error, RunStatus.Interrupted, RunStatus.Pending, RunStatus.Success, RunStatus.Timeout)]
    [DataMember(Name = "status", Order = 2), JsonPropertyName("status"), JsonPropertyOrder(2), YamlMember(Alias = "status", Order = 2)]
    public virtual string? Status { get; set; }

    /// <summary>
    /// Gets or sets the metadata keys and values, if any, to filter runs by.
    /// </summary>
    [Description("The metadata keys and values, if any, to filter runs by.")]
    [DataMember(Name = "metadata", Order = 3), JsonPropertyName("metadata"), JsonPropertyOrder(3), YamlMember(Alias = "metadata", Order = 3)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; } = null!;

    /// <summary>
    /// Gets/sets the maximum number of runs to return. Defaults to '10'.
    /// </summary>
    [Description("The maximum number of runs to return. Defaults to '10'.")]
    [Range(MinimumLimit, MaximumLimit)]
    [DataMember(Name = "limit", Order = 4), JsonPropertyName("limit"), JsonPropertyOrder(4), YamlMember(Alias = "limit", Order = 4)]
    public virtual uint Limit { get; set; } = DefaultLimit;

    /// <summary>
    /// Gets/sets the offset to start listing runs from. Defaults to '0'.
    /// </summary>
    [Description("The offset to start listing runs from. Defaults to '0'.")]
    [DataMember(Name = "offset", Order = 5), JsonPropertyName("offset"), JsonPropertyOrder(5), YamlMember(Alias = "offset", Order = 54)]
    public virtual uint Offset { get; set; } = DefaultLimit;

}