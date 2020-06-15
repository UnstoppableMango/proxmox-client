using UnMango.Proxmox.Client.Clients;

namespace UnMango.Proxmox.Client
{
    /// <summary>
    /// Proxmox REST API abstraction.
    /// </summary>
    public interface IProxmoxClient
    {
        /// <summary>
        /// Gets the access client.
        /// </summary>
        IAccessClient Access { get; }

        /// <summary>
        /// Gets the cluster client.
        /// </summary>
        IClusterClient Cluster { get; }

        /// <summary>
        /// Gets the nodes client.
        /// </summary>
        INodesClient Nodes { get; }

        /// <summary>
        /// Gets the pools client.
        /// </summary>
        IPoolsClient Pools { get; }

        /// <summary>
        /// Gets the storage client.
        /// </summary>
        IStorageClient Storage { get; }
    }
}
