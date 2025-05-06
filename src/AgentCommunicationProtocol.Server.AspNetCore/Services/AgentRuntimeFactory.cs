namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents the default implementation of the <see cref="IAgentRuntimeFactory"/> interface.
/// </summary>
/// <param name="serviceProvider">The current <see cref="IServiceProvider"/>.</param>
/// <param name="agentRegistry">The service used to manage <see cref="Agent"/>s.</param>
public class AgentRuntimeFactory(IServiceProvider serviceProvider, IAgentRegistry agentRegistry)
    : IAgentRuntimeFactory
{

    /// <summary>
    /// Gets the current <see cref="IServiceProvider"/>.
    /// </summary>
    protected IServiceProvider ServiceProvider { get; } = serviceProvider;

    /// <summary>
    /// Gets the service used to manage <see cref="Agent"/>s.
    /// </summary>
    protected IAgentRegistry AgentRegistry { get; } = agentRegistry;

    /// <inheritdoc/>
    public virtual IAgentRuntime Create(string agentId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(agentId);
        var record = AgentRegistry.Get(agentId) ?? throw new ProblemDetailsException(Problems.AgentNotFound(agentId));
        var runtime = record.RuntimeFactory(ServiceProvider);
        return runtime;
    }
}