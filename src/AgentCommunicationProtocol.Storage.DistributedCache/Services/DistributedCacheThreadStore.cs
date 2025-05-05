namespace AgentCommunicationProtocol.Storage.DistributedCache.Services;

/// <summary>
/// Represents an <see cref="IThreadStore"/> implementation that leverages an <see cref="IDistributedCache"/>
/// </summary>
/// <param name="logger">The service used to perform logging</param>
/// <param name="cache">The service used to cache data</param>
/// <param name="jsonSerializer">The service used to serialize/deserialize data to/from JSON</param>
public class DistributedCacheThreadStore(ILogger<DistributedCacheThreadStore> logger, IDistributedCache cache, IJsonSerializer jsonSerializer)
    : ThreadStoreBase
{

    /// <summary>
    /// Gets the service used to perform logging
    /// </summary>
    protected ILogger Logger { get; } = logger;

    /// <summary>
    /// Gets the service used to cache data
    /// </summary>
    protected IDistributedCache Cache { get; } = cache;

    /// <summary>
    /// Gets the service used to serialize/deserialize data to/from JSON
    /// </summary>
    protected IJsonSerializer JsonSerializer { get; } = jsonSerializer;

    /// <summary>
    /// Gets the thread index's cache key
    /// </summary>
    protected virtual string ThreadIndexKey { get; } = "acp-thread:index";

    /// <inheritdoc/>
    public override async Task<IThreadRecord> CreateAsync(string? id = null, IDictionary<string, object>? metadata = null, string ifExists = ThreadIfExistStrategy.Raise, CancellationToken cancellationToken = default)
    {
        var thread = string.IsNullOrWhiteSpace(id) ? null : await GetAsync(id, cancellationToken).ConfigureAwait(false);
        if (thread != null)
        {
            if (ifExists == ThreadIfExistStrategy.Raise) throw new ProblemDetailsException(Problems.ThreadAlreadyExists(id!));
            else return thread;
        }
        thread = new ThreadRecord()
        {
            Id = id ?? Guid.NewGuid().ToString("N"),
            CreatedAt = DateTimeOffset.Now,
            UpdatedAt = DateTimeOffset.Now,
            Metadata = metadata == null ? null : new(metadata),
            Checkpoint = new()
            {
                Id = Guid.NewGuid().ToString("N")
            }
        };
        var key = BuildRecordCacheKey(thread.Id);
        var json = JsonSerializer.SerializeToText(thread);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        json = await Cache.GetStringAsync(ThreadIndexKey, cancellationToken).ConfigureAwait(false);
        var index = string.IsNullOrWhiteSpace(json) ? [] : JsonSerializer.Deserialize<List<string>>(json)!;
        index.Add(thread.Id);
        json = JsonSerializer.SerializeToText(index);
        await Cache.SetStringAsync(ThreadIndexKey, json, cancellationToken).ConfigureAwait(false);
        return thread;
    }

    /// <inheritdoc/>
    public override async Task<IThreadRecord?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var key = BuildRecordCacheKey(id);
        var json = await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) return null;
        else return JsonSerializer.Deserialize<ThreadRecord>(json)!;
    }

    /// <inheritdoc/>
    public override async IAsyncEnumerable<IThreadRecord> ListAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var json = await Cache.GetStringAsync(ThreadIndexKey, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) yield break;
        var index = JsonSerializer.Deserialize<List<string>>(json)!;
        foreach(var id in index) yield return (await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
    }

    /// <inheritdoc/>
    public override async Task<IThreadRecord> PatchAsync(string id, Models.ThreadState state, CancellationToken cancellationToken = default)
    {
        var thread = (ThreadRecord)(await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
        thread = thread with
        {
            UpdatedAt = DateTimeOffset.Now,
            Checkpoint = state.Checkpoint,
            Values = state.Values,
            Messages = state.Messages,
            Metadata = state.Metadata
        };
        var key = BuildRecordCacheKey(thread.Id);
        var json = JsonSerializer.SerializeToText(thread);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        return thread;
    }

    /// <inheritdoc/>
    public override async Task<IThreadRecord> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var thread = (await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
        var key = BuildRecordCacheKey(id);
        await Cache.RemoveAsync(key, cancellationToken).ConfigureAwait(false);
        var json = await Cache.GetStringAsync(ThreadIndexKey, cancellationToken).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(json))
        {
            var index = JsonSerializer.Deserialize<List<string>>(json)!;
            index.Remove(id);
            json = JsonSerializer.SerializeToText(index);
            await Cache.SetStringAsync(ThreadIndexKey, json, cancellationToken).ConfigureAwait(false);
        }
        return thread;
    }

    /// <summary>
    /// Builds a new cache key for the specified thread
    /// </summary>
    /// <param name="id">The unique identifier of the thread to build a new cache key for</param>
    /// <returns>A new cache key for the specified thread</returns>
    protected virtual string BuildRecordCacheKey(string id) => $"acp-thread:{id}";

}
