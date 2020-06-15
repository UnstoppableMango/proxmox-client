using UnMango.Proxmox.Client.Clients;

namespace UnMango.Proxmox.Client
{
    public interface IProxmoxClient
    {
        IAccessClient Access { get; }

        IClusterClient Cluster { get; }

        INodesClient Nodes { get; }

        IPoolsClient Pools { get; }

        IStorageClient Storage { get; }
    }
}
