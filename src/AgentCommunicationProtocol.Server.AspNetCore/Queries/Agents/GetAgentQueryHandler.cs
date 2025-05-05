using AgentCommunicationProtocol.Queries.Agents;

namespace AgentCommunicationProtocol.Server.Queries.Agents;

/// <summary>
/// Represents the service used to handle <see cref="GetAgentQuery"/> instances
/// </summary>
/// <param name="agentRegistry">The service used to manage <see cref="Agent"/>s</param>
public sealed class GetAgentQueryHandler(IAgentRegistry agentRegistry)
    : IQueryHandler<GetAgentQuery, Agent>
{

    /// <inheritdoc/>
    public Task<IOperationResult<Agent>> HandleAsync(GetAgentQuery query, CancellationToken cancellationToken = default) => Task.FromResult(this.Ok(agentRegistry.Get(query.Id).AsAgent()));

}
