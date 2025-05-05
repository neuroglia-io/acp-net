using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="DeleteThreadCommand"/>s
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class DeleteThreadCommandHandler(IThreadStore threadManager)
    : ICommandHandler<DeleteThreadCommand>
{

    /// <inheritdoc/>
    public async Task<IOperationResult> HandleAsync(DeleteThreadCommand command, CancellationToken cancellationToken = default)
    {
        await threadManager.DeleteAsync(command.ThreadId, cancellationToken).ConfigureAwait(false);
        return this.Ok();
    }

}
