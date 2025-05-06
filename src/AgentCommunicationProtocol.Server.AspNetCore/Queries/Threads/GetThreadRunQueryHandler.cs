using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="GetThreadRunQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class GetThreadRunQueryHandler(IThreadStore threadManager)
    : IQueryHandler<GetThreadRunQuery, StatefulRun>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<StatefulRun>> HandleAsync(GetThreadRunQuery query, CancellationToken cancellationToken = default)
    {
        var record = await threadManager.GetRunAsync(query.ThreadId, query.RunId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.RunNotFound(query.RunId));
        return this.Ok(record.AsRun());
    }

}