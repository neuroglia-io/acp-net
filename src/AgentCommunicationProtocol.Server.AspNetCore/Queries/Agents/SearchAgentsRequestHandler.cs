using AgentCommunicationProtocol.Queries.Agents;

namespace AgentCommunicationProtocol.Server.Queries.Agents;

/// <summary>
/// Represents the service used to handle <see cref="SearchAgentsQuery"/> instances
/// </summary>
/// <param name="agentRegistry">The service used to manage <see cref="Agent"/>s</param>
public sealed class SearchAgentsQueryHandler(IAgentRegistry agentRegistry)
    : IQueryHandler<SearchAgentsQuery, IEnumerable<Agent>>
{

    /// <inheritdoc/>
    public Task<IOperationResult<IEnumerable<Agent>>> HandleAsync(SearchAgentsQuery query, CancellationToken cancellationToken = default)
    {
        var agents = agentRegistry.List();
        if (!string.IsNullOrWhiteSpace(query.Name)) agents = agents.Where(a => a.Metadata.Ref.Name == query.Name);
        if (!string.IsNullOrWhiteSpace(query.Version)) agents = agents.Where(a => a.Metadata.Ref.Version == query.Version);
        agents = agents.Skip((int)query.Offset);
        agents = agents.Take((int)query.Limit);
        return Task.FromResult(this.Ok(agents.Select(a => a.AsAgent())));
    }

}
