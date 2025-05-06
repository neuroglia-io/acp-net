using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="CancelThreadRunCommand"/>s.
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s.</param>
/// <param name="runExecutor">The service used to execute <see cref="Run"/>s.</param>
public sealed class CancelThreadRunCommandHandler(IThreadStore threadStore, IRunExecutor runExecutor)
    : ICommandHandler<CancelThreadRunCommand>
{

    /// <inheritdoc/>
    public async Task<IOperationResult> HandleAsync(CancelThreadRunCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadStore.GetRunAsync(command.ThreadId, command.RunId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.RunNotFound(command.RunId));
        if (record.Status != RunStatus.Pending && record.Status != RunStatus.Interrupted) throw new ProblemDetailsException(Problems.UnexpectedRunStatus(record.Id, record.Status));
        await runExecutor.CancelAsync(command.RunId, cancellationToken).ConfigureAwait(false);
        return this.Ok();
    }

}