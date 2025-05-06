using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="CreateAndStreamThreadRunCommand"/>s
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s</param>
/// <param name="runExecutor">The service used to execute <see cref="Run"/>s</param>
public sealed class CreateAndStreamThreadRunCommandHandler(IThreadStore threadStore, IRunExecutor runExecutor)
    : ICommandHandler<CreateAndStreamThreadRunCommand, IAsyncEnumerable<RunOutputStreamEvent>>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<IAsyncEnumerable<RunOutputStreamEvent>>> HandleAsync(CreateAndStreamThreadRunCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadStore.CreateRunAsync(command.ThreadId, command.Options, cancellationToken).ConfigureAwait(false);
        var run = record.AsRun();
        var stream = runExecutor.ExecuteAsync(run, cancellationToken);
        return this.Ok(stream);
    }

}