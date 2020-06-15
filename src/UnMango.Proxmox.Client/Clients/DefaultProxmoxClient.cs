using System;

namespace UnMango.Proxmox.Client.Clients
{
    /// <inheritdoc />
    internal class DefaultProxmoxClient : IProxmoxClient
    {
        private readonly Lazy<IAccessClient> _access;
        private readonly Lazy<IClusterClient> _cluster;
        private readonly Lazy<INodesClient> _nodes;
        private readonly Lazy<IPoolsClient> _pools;
        private readonly Lazy<IStorageClient> _storage;

        public DefaultProxmoxClient(IServiceProvider services)
        {
            _access = resolve<IAccessClient>();
            _cluster = resolve<IClusterClient>();
            _nodes = resolve<INodesClient>();
            _pools = resolve<IPoolsClient>();
            _storage = resolve<IStorageClient>();

            Lazy<T> resolve<T>() => new Lazy<T>(() => (T)services.GetService(typeof(T)));
        }

        /// <inheritdoc />
        public IAccessClient Access => _access.Value;

        /// <inheritdoc />
        public IClusterClient Cluster => _cluster.Value;

        /// <inheritdoc />
        public INodesClient Nodes => _nodes.Value;

        /// <inheritdoc />
        public IPoolsClient Pools => _pools.Value;

        /// <inheritdoc />
        public IStorageClient Storage => _storage.Value;
    }
}
