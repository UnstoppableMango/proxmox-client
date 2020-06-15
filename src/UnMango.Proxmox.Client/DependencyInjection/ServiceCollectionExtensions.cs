using UnMango.Proxmox.Client;
using UnMango.Proxmox.Client.Clients;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see type="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the proxmox client and related services to the <see type="IServiceCollection" />.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddProxmoxClient(this IServiceCollection services) {
            services.AddLogging();
            services.AddOptions<ProxmoxOptions>();
            services.AddHttpClient();

            services.AddTransient<IProxmoxClient, DefaultProxmoxClient>();

            // TODO
            services.AddTransient<IAccessClient>();
            services.AddTransient<IClusterClient>();
            services.AddTransient<INodesClient>();
            services.AddTransient<IPoolsClient>();
            services.AddTransient<IStorageClient>();

            return services;
        }
    }
}
