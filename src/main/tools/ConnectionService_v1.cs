
using SimpleConnections.blueprints;

namespace SimpleConnections.tools
{
    public class ConnectionService_v1 : IConnectionService
    {
        public bool IsConnected => throw new NotImplementedException();

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