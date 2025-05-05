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
    /// Builds the configured ACP server
    /// </summary>
    void Build();

}
