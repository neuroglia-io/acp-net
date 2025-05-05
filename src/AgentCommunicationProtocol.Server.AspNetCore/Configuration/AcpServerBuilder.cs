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

    /// <inheritdoc/>
    public virtual void Build()
    {
        
    }

}
