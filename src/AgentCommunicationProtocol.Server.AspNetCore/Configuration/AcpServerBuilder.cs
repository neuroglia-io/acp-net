namespace AgentCommunicationProtocol.Server.Configuration;

/// <summary>
/// Represents the default implementation of the <see cref="IAcpServerBuilder"/> interface
/// </summary>
/// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
public class AcpServerBuilder(IServiceCollection services)
    : IAcpServerBuilder
{

    /// <inheritdoc/>
    public IServiceCollection Services { get; } = services;

    /// <summary>
    /// Gets the type of <see cref="IBackgroundWorker"/> type to use
    /// </summary>
    protected Type BackgroundWorkerType { get; private set; } = typeof(Services.BackgroundWorker);

    /// <summary>
    /// Gets the type of <see cref="IAgentRegistry"/> type to use
    /// </summary>
    protected Type AgentRegistryType { get; private set; } = typeof(AgentRegistry);

    /// <summary>
    /// Gets the type of <see cref="IAgentRuntimeFactory"/> type to use
    /// </summary>
    protected Type AgentRuntimeFactoryType { get; private set; } = typeof(AgentRuntimeFactory);

    /// <summary>
    /// Gets the type of <see cref="IRunExecutor"/> type to use
    /// </summary>
    protected Type RunExecutorType { get; private set; } = typeof(RunExecutor);

    /// <inheritdoc/>
    public virtual IAcpServerBuilder WithBackgroundWorker<TWorker>()
        where TWorker : class, IBackgroundWorker
    {
        AgentRegistryType = typeof(TWorker);
        return this;
    }

    /// <inheritdoc/>
    public virtual IAcpServerBuilder WithAgentRegistry<TRegistry>()
        where TRegistry : class, IAgentRegistry
    {
        AgentRegistryType = typeof(TRegistry);
        return this;
    }

    /// <inheritdoc/>
    public virtual IAcpServerBuilder WithAgentRuntimeFactory<TFactory>()
        where TFactory : class, IAgentRuntimeFactory
    {
        AgentRuntimeFactoryType = typeof(TFactory);
        return this;
    }

    /// <inheritdoc/>
    public virtual IAcpServerBuilder WithRunExecutor<TExecutor>()
        where TExecutor : class, IRunExecutor
    {
        RunExecutorType = typeof(TExecutor);
        return this;
    }

    /// <inheritdoc/>
    public virtual void Build()
    {
        Services.TryAdd(new ServiceDescriptor(typeof(IBackgroundWorker), BackgroundWorkerType, ServiceLifetime.Singleton));
        Services.TryAdd(new ServiceDescriptor(typeof(IAgentRegistry), AgentRegistryType, ServiceLifetime.Singleton));
        Services.TryAdd(new ServiceDescriptor(typeof(IAgentRuntimeFactory), AgentRuntimeFactoryType, ServiceLifetime.Singleton));
        Services.TryAdd(new ServiceDescriptor(typeof(IRunExecutor), RunExecutorType, ServiceLifetime.Singleton));
    }

}
