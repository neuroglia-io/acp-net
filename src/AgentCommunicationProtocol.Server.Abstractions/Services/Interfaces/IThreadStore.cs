namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Defines the fundamentals of a service used to manage <see cref="Models.Thread"/>s.
/// </summary>
public interface IThreadStore
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
    /// Creates a new <see cref="StatefulRun"/>.
    /// </summary>
    /// <param name="threadId">The id of the thread the run to create belongs to.</param>
    /// <param name="options">The options used to configure the run to create.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="StatefulRun"/>.</returns>
    Task<IStatefulRunRecord> CreateRunAsync(string threadId, StatefulRunCreationOptions options, CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether or not the specified <see cref="Models.Thread"/> exists.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Models.Thread"/> to check.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A boolean indicating whether or not the specified <see cref="Models.Thread"/> exists.</returns>
    Task<bool> ExistsAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether or not the specified <see cref="StatefulRun"/> exists.
    /// </summary>
    /// <param name="threadId">The unique identifier of the <see cref="Models.Thread"/> the <see cref="StatefulRun"/> to check belongs to.</param>
    /// <param name="runId">The unique identifier of the <see cref="StatefulRun"/> to check.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A boolean indicating whether or not the specified <see cref="Models.Thread"/> exists.</returns>
    Task<bool> RunExistsAsync(string threadId, string runId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the <see cref="Models.Thread"/> with the specified id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The specified <see cref="Models.Thread"/>.</returns>
    Task<IThreadRecord?> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the specified <see cref="StatefulRun"/>.
    /// </summary>
    /// <param name="threadId">The id of the <see cref="Models.Thread"/> the <see cref="StatefulRun"/> to get belongs to.</param>
    /// <param name="runId">The id of the <see cref="StatefulRun"/> to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="StatefulRun"/> with the specified id, if any.</returns>
    Task<IStatefulRunRecord?> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all <see cref="Models.Thread"/>s.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to asynchronously enumerate <see cref="Models.Thread"/>s.</returns>
    IAsyncEnumerable<IThreadRecord> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists the <see cref="StatefulRun"/>s belonging to the specified <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="threadId">The id of the <see cref="Models.Thread"/> to list the <see cref="StatefulRun"/>s of.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IAsyncEnumerable{T}"/> used to asynchronously enumerate the specified <see cref="Models.Thread"/>'s <see cref="StatefulRun"/>s.</returns>
    IAsyncEnumerable<IStatefulRunRecord> ListRunsAsync(string threadId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resumes the specified <see cref="StatefulRun"/>.
    /// </summary>
    /// <param name="threadId">The unique identifier of the <see cref="Models.Thread"/> the <see cref="StatefulRun"/> to resume belongs to.</param>
    /// <param name="runId">The unique identifier of the <see cref="StatefulRun"/> to resume.</param>
    /// <param name="payload">The interrupt's payload.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The updated <see cref="IStatefulRunRecord"/>.</returns>
    Task<IStatefulRunRecord> ResumeRunAsync(string threadId, string runId, object payload, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the state of the specified <see cref="Models.Thread"/>.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to set the state of.</param>
    /// <param name="state">The <see cref="Models.Thread"/>'s updated state.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The updated <see cref="Models.Thread"/></returns>
    Task<IThreadRecord> SetStateAsync(string id, Models.ThreadState state, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the output of the specified <see cref="StatefulRun"/>.
    /// </summary>
    /// <param name="runId">The unique identifier of the <see cref="Models.Thread"/> the <see cref="StatefulRun"/> to set the output of belongs to.</param>
    /// <param name="runId">The unique identifier of the <see cref="StatefulRun"/> to set the output of.</param>
    /// <param name="output">The <see cref="StatefulRun"/>'s output.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The updated <see cref="StatefulRun"/>.</returns>
    Task<IStatefulRunRecord> SetRunOutputAsync(string threadId, string runId, RunOutput output, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the <see cref="Models.Thread"/> with the specified id.
    /// </summary>
    /// <param name="id">The id of the <see cref="Models.Thread"/> to delete.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>The deleted <see cref="Models.Thread"/>.</returns>
    Task<IThreadRecord> DeleteAsync(string id, CancellationToken cancellationToken = default);

}
