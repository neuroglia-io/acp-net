using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="CreateThreadCommand"/>s
/// </summary>
/// <param name="threadManager">The service used to manage <see cref="Models.Thread"/>s</param>
public sealed class CreateThreadCommandHandler(IThreadStore threadManager)
    : ICommandHandler<CreateThreadCommand, Models.Thread>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<Models.Thread>> HandleAsync(CreateThreadCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadManager.CreateAsync(command.ThreadId, command.Metadata, command.IfExists, cancellationToken).ConfigureAwait(false);
        return this.Ok(record.AsThread());
    }

}
