using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="GetThreadHistoryQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class GetThreadHistoryQueryHandler(IThreadStore threadManager)
    : IQueryHandler<GetThreadHistoryQuery, Models.ThreadState>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<Models.ThreadState>> HandleAsync(GetThreadHistoryQuery query, CancellationToken cancellationToken = default)
    {
        var thread = await threadManager.GetAsync(query.Id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(query.Id));
        return this.Ok(thread.GetState());
    }

}
