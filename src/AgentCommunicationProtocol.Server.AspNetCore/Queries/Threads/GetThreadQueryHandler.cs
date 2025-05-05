using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Queries.Threads;

/// <summary>
/// Represents the service used to handle <see cref="GetThreadQuery"/> instances
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class GetThreadQueryHandler(IThreadStore threadManager)
    : IQueryHandler<GetThreadQuery, Models.Thread>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<Models.Thread>> HandleAsync(GetThreadQuery query, CancellationToken cancellationToken = default)
    {
        var thread = await threadManager.GetAsync(query.Id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(query.Id));
        return this.Ok(thread.AsThread());
    }

}