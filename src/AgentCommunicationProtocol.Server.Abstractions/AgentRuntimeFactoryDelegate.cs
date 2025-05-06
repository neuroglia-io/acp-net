namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Represents the delegate function used to create a new <see cref="IAgentRuntime"/>.
/// </summary>
/// <param name="serviceProvider">The current <see cref="IServiceProvider"/>.</param>
/// <returns>A new <see cref="IAgentRuntime"/> instance.</returns>
public delegate IAgentRuntime AgentRuntimeFactoryDelegate(IServiceProvider serviceProvider);
