namespace AgentCommunicationProtocol.Server.Configuration;

/// <summary>
/// Defines the fundamentals of a service used to build an ACP server
/// </summary>
public interface IAcpServerBuilder
{

    /// <summary>
    /// Gets the <see cref="IServiceCollection"/> to configure
    /// </summary>
    IServiceCollection Services { get; }

    /// <summary>
    /// Configures the ACP server to use the specified <see cref="IBackgroundWorker"/>.
    /// </summary>
    /// <typeparam name="TWorker">The type of <see cref="IBackgroundWorker"/> to use.</typeparam>
    /// <returns>The configured <see cref="IAcpServerBuilder"/>.</returns>
    IAcpServerBuilder WithBackgroundWorker<TWorker>()
        where TWorker : class, IBackgroundWorker;

    /// <summary>
    /// Configures the ACP server to use the specified <see cref="IAgentRegistry"/>.
    /// </summary>
    /// <typeparam name="TRegistry">The type of <see cref="IAgentRegistry"/> to use.</typeparam>
    /// <returns>The configured <see cref="IAcpServerBuilder"/>.</returns>
    IAcpServerBuilder WithAgentRegistry<TRegistry>()
        where TRegistry : class, IAgentRegistry;

    /// <summary>
    /// Configures the ACP server to use the specified <see cref="IAgentRuntimeFactory"/>.
    /// </summary>
    /// <typeparam name="TRegistry">The type of <see cref="IAgentRuntimeFactory"/> to use.</typeparam>
    /// <returns>The configured <see cref="IAcpServerBuilder"/>.</returns>
    IAcpServerBuilder WithAgentRuntimeFactory<TFactory>()
        where TFactory : class, IAgentRuntimeFactory;

    /// <summary>
    /// Configures the ACP server to use the specified <see cref="IRunExecutor"/>.
    /// </summary>
    /// <typeparam name="TRegistry">The type of <see cref="IRunExecutor"/> to use.</typeparam>
    /// <returns>The configured <see cref="IAcpServerBuilder"/>.</returns>
    IAcpServerBuilder WithRunExecutor<TExecutor>()
        where TExecutor : class, IRunExecutor;

    /// <summary>
    /// Builds the configured ACP server
    /// </summary>
    void Build();

}
