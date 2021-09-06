using System.Net.Http;
using JetBrains.Annotations;
using UnMango.Proxmox.Generated.Api;

namespace UnMango.Proxmox.Client
{
    [PublicAPI]
    public static class ProxmoxClient
    {
        public static IDefaultApi Create(string basePath, string username, string password)
        {
            var authHandler = new AuthenticationHandler(basePath, username, password);
            return new DefaultApi(new HttpClient(authHandler));
        }
    }
}
