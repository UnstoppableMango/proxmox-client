using UnMango.Proxmox.Client.Clients.Access;

namespace UnMango.Proxmox.Client.Clients
{
    /// <summary>
    /// Proxmox access endpoint abstraction.
    /// </summary>
    public interface IAccessClient
    {
        /// <summary>
        /// Gets the domains client.
        /// </summary>
        IDomainsClient Domains { get; }

        /// <summary>
        /// Gets the groups client.
        /// </summary>
        IGroupsClient Groups { get; }

        /// <summary>
        /// Gets the roles client.
        /// </summary>
        IRolesClient Roles { get; }

        /// <summary>
        /// Gets the users client.
        /// </summary>
        IUsersClient Users { get; }
    }
}
