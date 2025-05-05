namespace AgentCommunicationProtocol.Queries.Threads;

/// <summary>
/// Represents the query used to list the runs that belong to a specified thread.
/// </summary>
[Description("Represents the query used to list the runs that belong to a specified thread.")]
[DataContract]
public class ListThreadRunsQuery
    : Query<IEnumerable<AgentRun>>
{

    /// <summary>
    /// Gets the minimum amount of runs that can be returned by a search query.
    /// </summary>
    public const int MinimumLimit = 1;
    /// <summary>
    /// Gets the maximum amount of runs that can be returned by a search query.
    /// </summary>
    public const int MaximumLimit = 1000;
    /// <summary>
    /// Gets the default amount of runs returned by a search query.
    /// </summary>
    public const int DefaultLimit = 10;

    /// <summary>
    /// Gets or sets the unique identifier of the thread to list the runs of.
    /// </summary>
    [Description("The unique identifier of the thread to list the runs of.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets/sets the maximum number of runs to return. Defaults to '10'.
    /// </summary>
    [Description("The maximum number of runs to return. Defaults to '10'.")]
    [Range(MinimumLimit, MaximumLimit)]
    [DataMember(Name = "limit", Order = 2), JsonPropertyName("limit"), JsonPropertyOrder(2), YamlMember(Alias = "limit", Order = 2)]
    public virtual uint Limit { get; set; } = DefaultLimit;

    /// <summary>
    /// Gets/sets the offset to start listing runs from. Defaults to '0'.
    /// </summary>
    [Description("The offset to start listing runs from. Defaults to '0'.")]
    [DataMember(Name = "offset", Order = 3), JsonPropertyName("offset"), JsonPropertyOrder(3), YamlMember(Alias = "offset", Order = 3)]
    public virtual uint Offset { get; set; }

}