
namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Handles low-level peer-to-peer networking logic including connection management and messaging.
    /// </summary>
    public interface IConnectionService
    {
        /// <summary>
        /// Starts listening for incoming peer connections on the given port.
        /// </summary>
        void StartListener(int port);

        /// <summary>
        /// Connects to a specific peer using string <c>ip</c> and int <c>port</c>.
        /// <code>
        /// ConnectToPeer("http://192.168.1.160", 8080);
        /// </code>
        /// </summary>
        void ConnectToPeer(string ip, int port);

        /// <summary>
        /// Sends a message to the currently connected peer.
        /// </summary>
        void Send(string message);

        /// <summary>
        /// Event triggered when a new message is received from a peer.
        /// </summary>
        event Action<string> OnMessageReceived;

        /// <summary>
        /// Disconnects from the currently connected peer.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Indicates whether a peer connection is currently active.
        /// </summary>
        bool IsConnected { get; }
    }
}