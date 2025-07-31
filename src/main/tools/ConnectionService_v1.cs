
using SimpleConnections.blueprints;

namespace SimpleConnections.tools
{
    public class ConnectionService_v1 : IConnectionService
    {
        /// <summary>Indicates whether a connection is currently active.</summary>
        public bool IsConnected => throw new NotImplementedException();
        /// <summary>Event raised when a message is received from a peer.</summary>
        public event Action<string> OnMessageReceived;

        public void ConnectToPeer(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Send(string message)
        {
            throw new NotImplementedException();
        }

        public void StartListener(int port)
        {
            throw new NotImplementedException();
        }
    }
}