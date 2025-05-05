namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to manage <see cref="Models.Thread"/>s.
/// </summary>
public interface IThreadStore
    : IObservable<ThreadLifecycleEvent>
{

    /// <summary>
    /// Creates a new <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="id">The unique identifier, if any, of the thread to create.</param>
    /// <param name="metadata">A key/value mapping of the metadata properties, if any, to associate to the thread to create.</param>
    /// <param name="ifExists">The strategy to adopt if the thread to create already exists.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="Models.Thread"/>.</returns>
    Task<IThreadRecord> CreateAsync(string? id = null, IDictionary<string, object>? metadata = null, string ifExists = ThreadIfExistStrategy.Raise, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the <see cref="Models.Thread"/> with the specified id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The specified <see cref="Models.Thread"/>.</returns>
    Task<IThreadRecord?> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all <see cref="Models.Thread"/>s.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to asynchronously enumerate <see cref="Models.Thread"/>s.</returns>
    IAsyncEnumerable<IThreadRecord> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Patches the specified <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to patch.</param>
    /// <param name="state">The <see cref="Models.Thread"/>'s updated state.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The patched <see cref="Models.Thread"/></returns>
    Task<IThreadRecord> PatchAsync(string id, Models.ThreadState state, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the <see cref="Models.Thread"/> with the specified id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to delete.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new awaitable <see cref="Task"/>.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

}
