using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="ListThreadRunsQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class ListThreadRunsQueryHandler(IThreadStore threadManager)
    : IQueryHandler<ListThreadRunsQuery, IEnumerable<StatefulRun>>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<IEnumerable<StatefulRun>>> HandleAsync(ListThreadRunsQuery query, CancellationToken cancellationToken = default)
    {
        var runs = (IEnumerable<StatefulRun>)await threadManager.ListRunsAsync(query.ThreadId, cancellationToken).Select(t => t.AsRun()).ToListAsync(cancellationToken).ConfigureAwait(false);
        runs = runs.Skip((int)query.Offset);
        runs = runs.Take((int)query.Limit);
        return this.Ok(runs);
    }

}
