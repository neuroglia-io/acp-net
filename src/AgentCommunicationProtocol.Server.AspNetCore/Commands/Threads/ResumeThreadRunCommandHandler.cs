using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="ResumeThreadRunCommand"/>s
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s</param>
/// <param name="backgroundWorker">The service used to perform work in the background</param>
public sealed class ResumeThreadRunCommandHandler(IThreadStore threadStore, IBackgroundWorker backgroundWorker)
    : ICommandHandler<ResumeThreadRunCommand, StatefulRun>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<StatefulRun>> HandleAsync(ResumeThreadRunCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadStore.ResumeRunAsync(command.ThreadId, command.RunId, command.Payload, cancellationToken).ConfigureAwait(false);
        var run = record.AsRun();
        await backgroundWorker.EnqueueJobAsync(async (provider, token) =>
        {
            await foreach (var _ in provider.GetRequiredService<IRunExecutor>().ExecuteAsync(run, token).ConfigureAwait(false)) { }
        }, false, cancellationToken).ConfigureAwait(false);
        return this.Ok(run);
    }

}
