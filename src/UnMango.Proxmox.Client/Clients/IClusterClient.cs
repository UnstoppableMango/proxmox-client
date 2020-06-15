using UnMango.Proxmox.Client.Clients.Cluster;

namespace UnMango.Proxmox.Client.Clients
{
    /// <summary>
    /// Proxmox cluster endpoint abstraction.
    /// </summary>
    public interface IClusterClient
    {
        /// <summary>
        /// Gets the acme client.
        /// </summary>
        IAcmeClient Acme { get; }

        /// <summary>
        /// Gets the backup client.
        /// </summary>
        IBackupClient Backup { get; }

        /// <summary>
        /// Gets the ceph client.
        /// </summary>
        ICephClient Ceph { get; }

        /// <summary>
        /// Gets the config client.
        /// </summary>
        IConfigClient Config { get; }

        /// <summary>
        /// Gets the firewall client.
        /// </summary>
        IFirewallClient Firewall { get; }

        /// <summary>
        /// Gets the ha client.
        /// </summary>
        IHaClient Ha { get; }

        /// <summary>
        /// Gets the replication client.
        /// </summary>
        IReplicationClient Replication { get; }

        /// <summary>
        /// Gets the sdn client.
        /// </summary>
        ISdnClient Sdn { get; }
    }
}
