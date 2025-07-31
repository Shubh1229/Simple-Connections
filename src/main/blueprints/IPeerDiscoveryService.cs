

namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Provides logic for discovering peers on a local network and retrieving known peer information.
    /// Used for auto-connection features and local presence tracking.
    /// </summary>
    public interface IPeerDiscoveryService
    {
        /// <summary>
        /// Starts broadcasting availability on the specified port for discovery by other peers.
        /// </summary>
        void StartBroadcast(int port);
        /// <summary>
        /// Retrieves a list of discovered peers, typically on the same LAN.
        /// </summary>
        List<PeerInfo> GetDiscoveredPeers();
    }
    /// <summary>
    /// Represents metadata about a discovered peer.
    /// Can be expanded to include IP, port, username, and status.
    /// </summary>
    public class PeerInfo
    {
    }
}