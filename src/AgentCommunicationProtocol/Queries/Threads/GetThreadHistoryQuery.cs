namespace AgentCommunicationProtocol.Queries.Threads;

/// <summary>
/// Represents the query used to retrieve the history of a thread.
/// </summary>
[Description("Represents the query used to retrieve the history of a thread.")]
[DataContract]
public class GetThreadHistoryQuery
    : Query<Models.ThreadState>
{

    /// <summary>
    /// Gets or sets the id of the thread to get the history of.
    /// </summary>
    [Description("The id of the agent to get the history of.")]
    [Required, MinLength(1)]
    [DataMember(Name = "id", Order = 1), JsonPropertyName("id"), JsonPropertyOrder(1), YamlMember(Alias = "id", Order = 1)]
    public virtual required string Id { get; set; }

}
