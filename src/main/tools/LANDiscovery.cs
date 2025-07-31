
using SimpleConnections.blueprints;

namespace SimpleConnections.tools
{
    /// <summary>
    /// Stubbed implementation of IPeerDiscoveryService for LAN-based peer discovery.
    /// Methods not yet implemented.
    /// </summary>
    public class LANDiscovery : IPeerDiscoveryService
    {
        public List<PeerInfo> GetDiscoveredPeers()
        {
            throw new NotImplementedException();
        }

        public void StartBroadcast(int port)
        {
            throw new NotImplementedException();
        }
    }
}