using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="PatchThreadCommand"/>s
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class PatchThreadCommandHandler(IThreadStore threadManager)
     : ICommandHandler<PatchThreadCommand, Models.Thread>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<Models.Thread>> HandleAsync(PatchThreadCommand command, CancellationToken cancellationToken = default)
    {
        var thread = await threadManager.PatchAsync(command.ThreadId, command.State, cancellationToken).ConfigureAwait(false);
        return this.Ok(thread.AsThread());
    }

}