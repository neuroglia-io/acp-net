namespace AgentCommunicationProtocol.Storage.DistributedCache;

/// <summary>
/// Defines extensions for <see cref="IAcpServerBuilder"/>s
/// </summary>
public static class IAcpServerBuilderExtensions
{

    /// <summary>
    /// Configures the <see cref="IAcpServerBuilder"/> to use <see cref="IDistributedCache"/>-based storage
    /// </summary>
    /// <param name="builder">The <see cref="IAcpServerBuilder"/> to configure</param>
    /// <returns>The configured <see cref="IAcpServerBuilder"/></returns>
    public static IAcpServerBuilder UseDistributedCacheStorage(this IAcpServerBuilder builder)
    {
        builder.Services.AddTransient<IThreadStore, DistributedCacheThreadStore>();
        return builder;
    }

}
