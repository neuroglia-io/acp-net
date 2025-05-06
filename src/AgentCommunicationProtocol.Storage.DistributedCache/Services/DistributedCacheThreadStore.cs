namespace AgentCommunicationProtocol.Storage.DistributedCache.Services;

/// <summary>
/// Represents an <see cref="IThreadStore"/> implementation that leverages an <see cref="IDistributedCache"/>.
/// </summary>
/// <param name="logger">The service used to perform logging.</param>
/// <param name="cache">The service used to cache data.</param>
/// <param name="jsonSerializer">The service used to serialize/deserialize data to/from JSON.</param>
public class DistributedCacheThreadStore(ILogger<DistributedCacheThreadStore> logger, IDistributedCache cache, IJsonSerializer jsonSerializer)
    : IThreadStore
{

    /// <summary>
    /// Gets the service used to perform logging.
    /// </summary>
    protected ILogger Logger { get; } = logger;

    /// <summary>
    /// Gets the service used to cache data.
    /// </summary>
    protected IDistributedCache Cache { get; } = cache;

    /// <summary>
    /// Gets the service used to serialize/deserialize data to/from JSON.
    /// </summary>
    protected IJsonSerializer JsonSerializer { get; } = jsonSerializer;

    /// <summary>
    /// Gets the thread index's cache key.
    /// </summary>
    protected virtual string ThreadIndexKey { get; } = "acp-threads-index";

    /// <inheritdoc/>
    public virtual async Task<IThreadRecord> CreateAsync(string? id = null, IDictionary<string, object>? metadata = null, string ifExists = ThreadIfExistStrategy.Raise, CancellationToken cancellationToken = default)
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
        var key = BuildThreadCacheKey(thread.Id);
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
    public virtual async Task<IStatefulRunRecord> CreateRunAsync(string threadId, StatefulRunCreationOptions options, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        ArgumentNullException.ThrowIfNull(options);
        var thread = await GetAsync(threadId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(threadId));
        var run = new StatefulRunRecord()
        {
            Id = Guid.NewGuid().ToString("N"),
            ThreadId = thread.Id,
            AgentId = thread.Id,
            CreatedAt = DateTimeOffset.Now,
            UpdatedAt = DateTimeOffset.Now,
            Creation = options
        };
        var key = BuildRunCacheKey(thread.Id, run.Id);
        var json = JsonSerializer.SerializeToText(run);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        key = BuildThreadRunIndexKey(thread.Id);
        json = await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);
        var index = string.IsNullOrWhiteSpace(json) ? [] : JsonSerializer.Deserialize<List<string>>(json)!;
        index.Add(run.Id);
        json = JsonSerializer.SerializeToText(index);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        return run;
    }

    /// <inheritdoc/>
    public virtual async Task<bool> ExistsAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var key = BuildThreadCacheKey(id);
        return string.IsNullOrWhiteSpace(await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false));
    }

    /// <inheritdoc/>
    public virtual async Task<bool> RunExistsAsync(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        var key = BuildRunCacheKey(threadId, runId);
        return string.IsNullOrWhiteSpace(await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false));
    }

    /// <inheritdoc/>
    public virtual async Task<IThreadRecord?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var key = BuildThreadCacheKey(id);
        var json = await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) return null;
        else return JsonSerializer.Deserialize<ThreadRecord>(json)!;
    }

    /// <inheritdoc/>
    public virtual async Task<IStatefulRunRecord?> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        var thread = await GetAsync(threadId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(threadId)); 
        return await GetRunAsync(threadId, runId, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets the specified <see cref="StatefulRun"/>.
    /// </summary>
    /// <param name="thread">The <see cref="Models.Thread"/> the <see cref="StatefulRun"/> to get belongs to.</param>
    /// <param name="runId">The id of the <see cref="StatefulRun"/> to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="StatefulRun"/> with the specified id, if any.</returns>
    protected virtual async Task<IStatefulRunRecord?> GetRunAsync(IThreadRecord thread, string runId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(thread);
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        var key = BuildRunCacheKey(thread.Id, runId);
        var json = await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) return null;
        else return JsonSerializer.Deserialize<StatefulRunRecord>(json)!;
    }

    /// <inheritdoc/>
    public virtual async IAsyncEnumerable<IThreadRecord> ListAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var json = await Cache.GetStringAsync(ThreadIndexKey, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) yield break;
        var index = JsonSerializer.Deserialize<List<string>>(json)!;
        foreach(var id in index) yield return (await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
    }

    /// <inheritdoc/>
    public virtual async IAsyncEnumerable<IStatefulRunRecord> ListRunsAsync(string threadId, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        var thread = await GetAsync(threadId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(threadId));
        var key = BuildThreadRunIndexKey(threadId);
        var json = await Cache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);
        if (string.IsNullOrWhiteSpace(json)) yield break;
        var index = JsonSerializer.Deserialize<List<string>>(json)!;
        foreach (var id in index) yield return (await GetRunAsync(thread, id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.RunNotFound(id)));
    }

    /// <inheritdoc/>
    public virtual async Task<IStatefulRunRecord> ResumeRunAsync(string threadId, string runId, object payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        ArgumentNullException.ThrowIfNull(payload);
        var run = (StatefulRunRecord)(await GetRunAsync(threadId, runId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.RunNotFound(runId)));
        if (run.Status != RunStatus.Interrupted) throw new ProblemDetailsException(Problems.UnexpectedRunStatus(run.Id, run.Status));
        run.Status = RunStatus.Pending;
        run.UpdatedAt = DateTimeOffset.Now;
        run.Creation.Input = payload;
        var key = BuildRunCacheKey(threadId, run.Id);
        var json = JsonSerializer.SerializeToText(run);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        return run;
    }

    /// <inheritdoc/>
    public virtual async Task<IThreadRecord> SetStateAsync(string id, Models.ThreadState state, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(state);
        var thread = (ThreadRecord)(await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
        thread = thread with
        {
            UpdatedAt = DateTimeOffset.Now,
            Checkpoint = state.Checkpoint,
            Values = state.Values,
            Messages = state.Messages,
            Metadata = state.Metadata
        };
        var key = BuildThreadCacheKey(thread.Id);
        var json = JsonSerializer.SerializeToText(thread);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        return thread;
    }

    /// <inheritdoc/>
    public virtual async Task<IStatefulRunRecord> SetRunOutputAsync(string threadId, string runId, RunOutput output, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(threadId);
        ArgumentException.ThrowIfNullOrWhiteSpace(runId);
        ArgumentNullException.ThrowIfNull(output);
        var run = (StatefulRunRecord)(await GetRunAsync(threadId, runId, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.RunNotFound(runId)));
        run = run with
        {
            Status = output switch
            {
                RunResult => RunStatus.Success,
                RunInterrupt => RunStatus.Interrupted,
                RunError => RunStatus.Error,
                _ => throw new NotSupportedException($"The specified output type '{output.Type}' is not supported.")
            },
            UpdatedAt = DateTimeOffset.Now,
            Output = output
        };
        var key = BuildRunCacheKey(threadId, run.Id);
        var json = JsonSerializer.SerializeToText(run);
        await Cache.SetStringAsync(key, json, cancellationToken).ConfigureAwait(false);
        return run;
    }

    /// <inheritdoc/>
    public virtual async Task<IThreadRecord> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var thread = (await GetAsync(id, cancellationToken).ConfigureAwait(false) ?? throw new ProblemDetailsException(Problems.ThreadNotFound(id)));
        var key = BuildThreadCacheKey(id);
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
    /// Builds a new cache key for the specified thread.
    /// </summary>
    /// <param name="id">The unique identifier of the thread to build a new cache key for.</param>
    /// <returns>A new cache key for the specified thread.</returns>
    protected virtual string BuildThreadCacheKey(string id) => $"acp-thread:{id}";

    /// <summary>
    /// Builds a new cache key for the specified run.
    /// </summary>
    /// <param name="threadId">The id of the thread the run to build a new cache key for belongs to.</param>
    /// <param name="runId">The unique identifier of the run to build a new cache key for.</param>
    /// <returns>A new cache key for the specified run.</returns>
    protected virtual string BuildRunCacheKey(string threadId, string runId) => $"acp-thread-run:{threadId}:{runId}";

    /// <summary>
    /// Builds a new cache key for the specified thread's run index.
    /// </summary>
    /// <param name="id">The unique identifier of the thread to build a new run index cache key for.</param>
    /// <returns>A new cache key for the specified thread's run index.</returns>
    protected virtual string BuildThreadRunIndexKey(string id) => $"acp-thread-runs-index:{id}";

}
