using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="CreateThreadBackgroundRunCommand"/>s
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s</param>
/// <param name="backgroundWorker">The service used to perform work in the background</param>
public sealed class CreateThreadBackgroundRunCommandHandler(IThreadStore threadStore, IBackgroundWorker backgroundWorker)
    : ICommandHandler<CreateThreadBackgroundRunCommand, StatefulRun>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<StatefulRun>> HandleAsync(CreateThreadBackgroundRunCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadStore.CreateRunAsync(command.ThreadId, command.Options, cancellationToken).ConfigureAwait(false);
        var run = record.AsRun();
        await backgroundWorker.EnqueueJobAsync(async (provider, token) =>
        {
            await foreach (var _ in provider.GetRequiredService<IRunExecutor>().ExecuteAsync(run, token).ConfigureAwait(false)) { }
        }, false, cancellationToken).ConfigureAwait(false);
        return this.Ok(run);
    }

}
