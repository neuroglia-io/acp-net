using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="ResumeThreadRunCommand"/>s.
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s.</param>
/// <param name="runExecutor">The service used to execute <see cref="Run"/>s.</param>
public sealed class StreamThreadRunOutputCommandHandler(IThreadStore threadStore, IRunExecutor runExecutor)
    : ICommandHandler<StreamThreadRunOutputCommand, IAsyncEnumerable<RunOutputStreamEvent>>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<IAsyncEnumerable<RunOutputStreamEvent>>> HandleAsync(StreamThreadRunOutputCommand command, CancellationToken cancellationToken = default)
    {
        if (!await threadStore.RunExistsAsync(command.ThreadId, command.RunId, cancellationToken).ConfigureAwait(false)) throw new ProblemDetailsException(Problems.RunNotFound(command.RunId));
        var stream = runExecutor.StreamOutputAsync(command.RunId);
        return this.Ok(stream);
    }

}
