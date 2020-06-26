using System;
using System.Net.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using UnMango.Proxmox.Client;
using UnMango.Proxmox.Client.Clients;
using UnMango.Proxmox.Client.Rest;

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
        public static IServiceCollection AddProxmoxClient(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddOptions<ProxmoxOptions>();
            services.AddHttpClient(ProxmoxOptions.HttpClientName)
                .ConfigureHttpClient(ConfigureClient);

            services.AddSingleton<IFlurlClientFactory, MicrosoftFlurlClientFactory>();
            services.AddTransient<IProxmoxClient, DefaultProxmoxClient>();

            // TODO
            services.AddTransient<IAccessClient>();
            services.AddTransient<IClusterClient>();
            services.AddTransient<INodesClient>();
            services.AddTransient<IPoolsClient>();
            services.AddTransient<IStorageClient>();

            return services;
        }

        private static void ConfigureClient(IServiceProvider services, HttpClient client)
        {
            var options = services.GetRequiredService<IOptions<ProxmoxOptions>>();
            client.BaseAddress = new Uri(options.Value.BaseAddress);
        }
    }
}
