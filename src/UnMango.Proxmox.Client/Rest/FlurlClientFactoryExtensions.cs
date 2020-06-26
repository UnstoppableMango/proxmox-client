using Flurl.Http;
using Flurl.Http.Configuration;

namespace UnMango.Proxmox.Client.Rest
{
    internal static class FlurlClientFactoryExtensions
    {
        public static IFlurlClient Get(this IFlurlClientFactory clientFactory)
        {
            return clientFactory.Get(null!); // TODO: Sensible default
        }
    }
}
