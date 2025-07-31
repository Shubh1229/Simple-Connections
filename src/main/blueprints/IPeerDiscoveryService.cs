

namespace SimpleConnections.blueprints
{
    public interface IPeerDiscoveryService
    {
        void StartBroadcast(int port);
        List<PeerInfo> GetDiscoveredPeers();
    }

    public class PeerInfo
    {
    }
}