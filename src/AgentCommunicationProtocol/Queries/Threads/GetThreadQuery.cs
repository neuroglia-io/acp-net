namespace AgentCommunicationProtocol.Queries.Threads;

/// <summary>
/// Represents the query used to retrieve a thread by id.
/// </summary>
[Description("Represents the query used to retrieve a thread by id.")]
[DataContract]
public class GetThreadQuery
    : Query<Models.Thread>
{

    /// <summary>
    /// Gets or sets the id of the thread to get.
    /// </summary>
    [Description("The id of the agent to get.")]
    [Required, MinLength(1)]
    [DataMember(Name = "id", Order = 1), JsonPropertyName("id"), JsonPropertyOrder(1), YamlMember(Alias = "id", Order = 1)]
    public virtual required string Id { get; set; }

}