namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents the default implementation of the <see cref="IAgentRegistry"/> interface
/// </summary>
public class AgentRegistry
    : IAgentRegistry
{

    /// <summary>
    /// Gets an id/record mapping of all registered agents
    /// </summary>
    protected ConcurrentDictionary<string, AgentRecord> Agents { get; } = [];

    /// <inheritdoc/>
    public virtual void Register(AgentMetadata metadata, AgentSpecs specs, AgentRuntimeFactoryDelegate runtimeFactory)
    {
        ArgumentNullException.ThrowIfNull(metadata);
        ArgumentNullException.ThrowIfNull(specs);
        ArgumentNullException.ThrowIfNull(runtimeFactory);
        if (Agents.Any(a => a.Value.Metadata.Ref.Name == metadata.Ref.Name && a.Value.Metadata.Ref.Version == metadata.Ref.Version)) throw new ProblemDetailsException(Problems.AgentNotFound(metadata.Ref.ToString()));
        var record = new AgentRecord()
        {
            Id = Guid.NewGuid().ToString("N"),
            Metadata = metadata,
            Specs = specs,
            RuntimeFactory = runtimeFactory
        };
        Agents.AddOrUpdate(record.Id, record, (existing, key) => record);
    }

    /// <inheritdoc/>
    public virtual void Deregister(string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        Agents.TryRemove(id, out _);
    }

    /// <inheritdoc/>
    public virtual IAgentRecord Get(string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        if(!Agents.TryGetValue(id, out var agent) || agent == null) throw new ProblemDetailsException(Problems.AgentNotFound(id));
        return agent;
    }

    /// <inheritdoc/>
    public virtual IAgentRecord Get(string name, string version)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(version);
        return Agents.FirstOrDefault(a => a.Value.Metadata.Ref.Name == name && a.Value.Metadata.Ref.Version == version).Value ?? throw new ProblemDetailsException(Problems.AgentNotFound($"{name}:{version}"));
    }

    /// <inheritdoc/>
    public virtual IEnumerable<IAgentRecord> List() => Agents.Values;

}
