namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Defines extensions for <see cref="IServiceCollection"/>s
/// </summary>
public static class IServiceCollectionExtensions
{

    /// <summary>
    /// Adds and configures an ACP server and related services
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the server</param>
    /// <returns>The configured <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddAcpServer(this IServiceCollection services, Action<IAcpServerBuilder> setup)
    {
        ArgumentNullException.ThrowIfNull(setup);
        services.AddSerialization();
        services.AddJsonSerializer();
        var builder = new AcpServerBuilder(services);
        setup(builder);
        builder.Build();
        return services;
    }

}
