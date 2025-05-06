namespace AgentCommunicationProtocol.Queries.Threads;

/// <summary>
/// Represents the query used to get a thread's run by id.
/// </summary>
public class GetThreadRunQuery
    : Query<StatefulRun>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread the run to get belongs to
    /// </summary>
    [Description("The unique identifier of the thread the run to get belongs to.")]
    [Required, MinLength(1)]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual required string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the run to get.
    /// </summary>
    [Description("The unique identifier of the run to get.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 2), JsonPropertyName("run_id"), JsonPropertyOrder(2), YamlMember(Alias = "run_id", Order = 2)]
    public virtual required string RunId { get; set; }

}