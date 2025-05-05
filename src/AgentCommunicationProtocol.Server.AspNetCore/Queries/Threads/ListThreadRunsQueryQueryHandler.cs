using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="ListThreadRunsQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class ListThreadRunsQueryQueryHandler(IThreadStore threadManager)
    : IQueryHandler<ListThreadRunsQuery, IEnumerable<AgentRun>>
{

    public async Task<IOperationResult<IEnumerable<AgentRun>>> HandleAsync(ListThreadRunsQuery query, CancellationToken cancellationToken = default)
    {
        
    }

}

