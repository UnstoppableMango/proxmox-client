using System.Net.Http;
using JetBrains.Annotations;
using UnMango.Proxmox.Generated.Api;

namespace UnMango.Proxmox.Client
{
    [PublicAPI]
    public static class ProxmoxClient
    {
        public static IDefaultApi Create(string basePath)
        {
            return new DefaultApi(new HttpClient());
        }
    }
}
