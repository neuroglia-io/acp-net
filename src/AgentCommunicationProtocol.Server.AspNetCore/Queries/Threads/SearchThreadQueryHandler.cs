using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="SearchThreadQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class SearchThreadQueryHandler(IThreadStore threadManager)
    : IQueryHandler<SearchThreadQuery, IEnumerable<Models.Thread>>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<IEnumerable<Models.Thread>>> HandleAsync(SearchThreadQuery query, CancellationToken cancellationToken = default)
    {
        var threads = (IEnumerable<Models.Thread>)await threadManager.ListAsync(cancellationToken).Select(t => t.AsThread()).ToListAsync(cancellationToken).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(query.Status)) threads = threads.Where(t => t.Status == query.Status);
        if (query.Metadata != null) threads = threads.Where(t => t.Metadata != null && query.Metadata.All(m => t.Metadata.ContainsKey(m.Key) && t.Metadata[m.Key] == m.Value));
        if (query.Values != null) threads = threads.Where(t => t.Values != null && query.Values.All(v => t.Values.ContainsKey(v.Key) && t.Values[v.Key] == v.Value));
        threads = threads.Skip((int)query.Offset);
        threads = threads.Take((int)query.Limit);
        return this.Ok(threads);
    }

}

