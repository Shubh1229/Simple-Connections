

namespace SimpleConnections.model
{
    using SimpleConnections.blueprints;
    using Terminal.Gui;
    public abstract class PageModel : Window
    {
        private readonly IBackground? background;
        private readonly IConnectionService? connection;
        private readonly IChatRoom? chatRoom;
        private readonly ILogger? logger;
        private readonly IMessageProtocol? protocol;
        private readonly IPeerDiscoveryService? peerDiscovery;
        public PageModel(string title, IBackground background, IConnectionService connection,
        ILogger logger, IMessageProtocol protocol, IPeerDiscoveryService peerDiscovery,
        IChatRoom chatRoom)
        {
            this.Title = title;
            this.background = background;
            this.connection = connection;
            this.logger = logger;
            this.protocol = protocol;
            this.peerDiscovery = peerDiscovery;
            this.chatRoom = chatRoom;
        }
        public PageModel() { }
        public abstract void InitializeComponent();
        public IConnectionService GetConnectionService()
        {
            return connection ?? throw new NullReferenceException("Connection Service is not initialized");
        }
        public IChatRoom GetChatRoom()
        {
            return chatRoom ?? throw new NullReferenceException("Chat Room is not initialized");
        }
        public IMessageProtocol GetMessageProtocol()
        {
            return protocol ?? throw new NullReferenceException("Message Protocol is not initialized");
        }
        public IPeerDiscoveryService GetPeerDiscoveryService()
        {
            return peerDiscovery ?? throw new NullReferenceException("Peer Discovery Service is not initialized");
        }
    }
}