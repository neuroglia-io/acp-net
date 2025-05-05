namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents the base class for all implementations of the <see cref="IThreadStore"/> interface
/// </summary>
public abstract class ThreadStoreBase
    : IThreadStore
{

    /// <summary>
    /// Gets the <see cref="ISubject{T}"/> used to stream <see cref="ThreadLifecycleEvent"/>s
    /// </summary>
    protected ISubject<ThreadLifecycleEvent> Subject { get; } = new Subject<ThreadLifecycleEvent>();

    /// <inheritdoc/>
    public virtual IDisposable Subscribe(IObserver<ThreadLifecycleEvent> observer) => Subject.Subscribe(observer);

    async Task<IThreadRecord> IThreadStore.CreateAsync(string? id, IDictionary<string, object>? metadata, string ifExists, CancellationToken cancellationToken)
    {
        var thread = await CreateAsync(id, metadata, ifExists, cancellationToken).ConfigureAwait(false);
        Subject.OnNext(new ThreadLifecycleEvent()
        {
            Type = ThreadLifecycleEventType.Created,
            Thread = thread
        });
        return thread;
    }

    /// <summary>
    /// Creates a new <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="id">The unique identifier, if any, of the thread to create.</param>
    /// <param name="metadata">A key/value mapping of the metadata properties, if any, to associate to the thread to create.</param>
    /// <param name="ifExists">The strategy to adopt if the thread to create already exists.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="Models.Thread"/>.</returns>
    public abstract Task<IThreadRecord> CreateAsync(string? id = null, IDictionary<string, object>? metadata = null, string ifExists = "raise", CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract Task<IThreadRecord?> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public abstract IAsyncEnumerable<IThreadRecord> ListAsync(CancellationToken cancellationToken = default);

    async Task<IThreadRecord> IThreadStore.PatchAsync(string id, Models.ThreadState state, CancellationToken cancellationToken)
    {
        var thread = await PatchAsync(id, state, cancellationToken).ConfigureAwait(false);
        Subject.OnNext(new ThreadLifecycleEvent()
        {
            Type = ThreadLifecycleEventType.Patched,
            Thread = thread
        });
        return thread;
    }

    /// <summary>
    /// Patches the specified <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to patch.</param>
    /// <param name="state">The <see cref="Models.Thread"/>'s updated state.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The patched <see cref="Models.Thread"/></returns>
    public abstract Task<IThreadRecord> PatchAsync(string id, Models.ThreadState state, CancellationToken cancellationToken = default);

    async Task IThreadStore.DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var thread = await DeleteAsync(id, cancellationToken).ConfigureAwait(false);
        Subject.OnNext(new ThreadLifecycleEvent()
        {
            Type = ThreadLifecycleEventType.Deleted,
            Thread = thread
        });
    }

    /// <summary>
    /// Deletes the <see cref="Models.Thread"/> with the specified id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to delete.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The deleted <see cref="Models.Thread"/>.</returns>
    public abstract Task<IThreadRecord> DeleteAsync(string id, CancellationToken cancellationToken = default);

}
