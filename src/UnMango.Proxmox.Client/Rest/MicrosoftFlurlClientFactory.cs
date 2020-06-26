using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace UnMango.Proxmox.Client.Rest
{
    using IHttpClientFactory = System.Net.Http.IHttpClientFactory;

    internal class MicrosoftFlurlClientFactory : PerBaseUrlFlurlClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MicrosoftFlurlClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override IFlurlClient Get(Url url)
        {
            var httpClient = _httpClientFactory.CreateClient(ProxmoxOptions.HttpClientName);

            if (httpClient != null) return new FlurlClient(httpClient);

            return base.Get(url);
        }
    }
}
