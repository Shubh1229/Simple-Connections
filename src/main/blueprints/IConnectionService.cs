
namespace SimpleConnections.blueprints
{
    public interface IConnectionService
    {
        void StartListener(int port);
        void ConnectToPeer(string ip, int port);
        void Send(string message);
        event Action<string> OnMessageReceived;
        void Disconnect();
        bool IsConnected { get; }
    }
}