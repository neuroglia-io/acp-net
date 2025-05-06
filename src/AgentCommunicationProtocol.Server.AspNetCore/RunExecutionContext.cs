namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Represents the object used to describe the execution context of a run.
/// </summary>
public class RunExecutionContext
    : IDisposable
{

    bool _disposed;

    /// <summary>
    /// Gets the run's output stream.
    /// </summary>
    public virtual required Subject<RunOutputStreamEvent> OutputStream { get; init; }

    /// <summary>
    /// Gets the run's <see cref="System.Threading.CancellationTokenSource"/>.
    /// </summary>
    public virtual required CancellationTokenSource CancellationTokenSource { get; init; }

    /// <summary>
    /// Disposes of the <see cref="RunExecutionContext"/>.
    /// </summary>
    /// <param name="disposing">A boolean indicating whether the <see cref="RunExecutionContext"/> is being disposed of.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                OutputStream.Dispose();
                CancellationTokenSource.Dispose();
            }
            _disposed = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}