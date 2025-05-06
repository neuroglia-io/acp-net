using AgentCommunicationProtocol.Commands.Threads;

namespace AgentCommunicationProtocol.Server.Commands.Threads;

/// <summary>
/// Represents the service used to handle <see cref="CreateAndWaitThreadRunCommand"/>s
/// </summary>
/// <param name="threadStore">The service used to manage <see cref="Models.Thread"/>s</param>
/// <param name="runExecutor">The service used to execute <see cref="Run"/>s</param>
public sealed class CreateAndWaitThreadRunCommandHandler(IThreadStore threadStore, IRunExecutor runExecutor)
    : ICommandHandler<CreateAndWaitThreadRunCommand, StatefulRunExecutionResult>
{

    /// <inheritdoc/>
    public async Task<IOperationResult<StatefulRunExecutionResult>> HandleAsync(CreateAndWaitThreadRunCommand command, CancellationToken cancellationToken = default)
    {
        var record = await threadStore.CreateRunAsync(command.ThreadId, command.Options, cancellationToken).ConfigureAwait(false);
        var run = record.AsRun();
        try { await foreach (var _ in runExecutor.ExecuteAsync(run, cancellationToken)) { } }
        catch { }
        record = (await threadStore.GetRunAsync(run.ThreadId!, run.Id, cancellationToken).ConfigureAwait(false))!;
        run = record.AsRun();
        var executionResult = new StatefulRunExecutionResult()
        {
            Run = run,
            Output = record.Output!
        };
        return this.Ok(executionResult);
    }

}