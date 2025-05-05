namespace AgentCommunicationProtocol.Queries.Agents;

/// <summary>
/// Represents the query used to get the ACP descriptor of an agent by id.
/// </summary>
[Description("Represents the query used to get the ACP descriptor of an agent by id.")]
[DataContract]
public class GetAgentDescriptorQuery
    : Query<AgentDescriptor>
{

    /// <summary>
    /// Gets or sets the id of the agent to get the ACP descriptor of.
    /// </summary>
    [Description("The id of the agent to get.")]
    [Required, MinLength(1)]
    [DataMember(Name = "id", Order = 1), JsonPropertyName("id"), JsonPropertyOrder(1), YamlMember(Alias = "id", Order = 1)]
    public virtual required string Id { get; set; }

}