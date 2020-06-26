using System;

namespace UnMango.Proxmox.Client
{
    public class ProxmoxOptions
    {
        public const string HttpClientName = "proxmox-client";

        public string BaseAddress { get; set; } = string.Empty;
    }
}
