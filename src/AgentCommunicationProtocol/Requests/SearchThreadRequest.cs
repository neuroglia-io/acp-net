namespace AgentCommunicationProtocol.Requests;

/// <summary>
/// Represents the request used to search for threads.
/// </summary>
[Description("Represents the request used to search for threads.")]
[DataContract]
public record SearchThreadRequest
{

    /// <summary>
    /// Gets the minium amount of threads that can be returned by a search request.
    /// </summary>
    public const int MinimumLimit = 1;
    /// <summary>
    /// Gets the maximum amount of threads that can be returned by a search request.
    /// </summary>
    public const int MaximumLimit = 1000;
    /// <summary>
    /// Gets the default amount of threads returned by a search request.
    /// </summary>
    public const int DefaultLimit = 10;

    /// <summary>
    /// Gets or sets the metadata keys and values, if any, to filter threads by.
    /// </summary>
    [Description("The metadata keys and values, if any, to filter threads by.")]
    [DataMember(Name = "metadata", Order = 1), JsonPropertyName("metadata"), JsonPropertyOrder(1), YamlMember(Alias = "metadata", Order = 1)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; } = null!;

    /// <summary>
    /// Gets or sets the state keys and values, if any, to filter threads by.
    /// </summary>
    [Description("The state keys and values, if any, to filter threads by.")]
    [DataMember(Name = "values", Order = 2), JsonPropertyName("values"), JsonPropertyOrder(2), YamlMember(Alias = "values", Order = 2)]
    public virtual EquatableDictionary<string, object>? Values { get; set; } = null!;

    /// <summary>
    /// Gets/sets the status, if any, to filter threads by.
    /// </summary>
    [Description("The status, if any, to filter threads by.")]
    [AllowedValues(ThreadStatus.Busy, ThreadStatus.Error, ThreadStatus.Idle, ThreadStatus.Interrupted)]
    [DataMember(Name = "status", Order = 3), JsonPropertyName("status"), JsonPropertyOrder(3), YamlMember(Alias = "status", Order = 3)]
    public virtual string? Status { get; set; }

    /// <summary>
    /// Gets/sets the maximum number of threads to return. Defaults to '10'.
    /// </summary>
    [Description("The maximum number of threads to return. Defaults to '10'.")]
    [Range(MinimumLimit, MaximumLimit)]
    [DataMember(Name = "limit", Order = 3), JsonPropertyName("limit"), JsonPropertyOrder(3), YamlMember(Alias = "limit", Order = 3)]
    public virtual uint Limit { get; set; } = DefaultLimit;

    /// <summary>
    /// Gets/sets the offset to start listing threads from. Defaults to '0'.
    /// </summary>
    [Description("The offset to start listing threads from. Defaults to '0'.")]
    [DataMember(Name = "offset", Order = 4), JsonPropertyName("offset"), JsonPropertyOrder(4), YamlMember(Alias = "offset", Order = 4)]
    public virtual uint Offset { get; set; } = DefaultLimit;

}
