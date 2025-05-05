using AgentCommunicationProtocol.Queries.Agents;

namespace AgentCommunicationProtocol.Server.Queries.Agents;

/// <summary>
/// Represents the service used to handle <see cref="GetAgentDescriptorQuery"/> instances
/// </summary>
/// <param name="agentRegistry">The service used to manage <see cref="AgentDescriptor"/>s</param>
public sealed class GetAgentDescriptorQueryHandler(IAgentRegistry agentRegistry)
    : IQueryHandler<GetAgentDescriptorQuery, AgentDescriptor>
{

    /// <inheritdoc/>
    public Task<IOperationResult<AgentDescriptor>> HandleAsync(GetAgentDescriptorQuery query, CancellationToken cancellationToken = default) => Task.FromResult(this.Ok(agentRegistry.Get(query.Id).AsDescriptor()));

}