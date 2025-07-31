

namespace SimpleConnections.model
{
    using SimpleConnections.blueprints;
    using Terminal.Gui;
    /// <summary>
    /// Abstract base class for all navigable UI pages. Inherits from Terminal.Gui.Window and provides
    /// shared service access for all implementing pages.
    /// </summary>
    public abstract class PageModel : Window
    {
        private readonly IBackground? background;
        private readonly IConnectionService? connection;
        private readonly IChatRoom? chatRoom;
        private readonly ILogger? logger;
        private readonly IMessageProtocol? protocol;
        private readonly IPeerDiscoveryService? peerDiscovery;
        /// <summary>UI title for the window.</summary>
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
        /// <summary>Must be implemented by child classes to construct UI content.</summary>
        public abstract void InitializeComponent();
        /// <summary>Returns the injected IConnectionService or throws if missing.</summary>
        public IConnectionService GetConnectionService()
        {
            return connection ?? throw new NullReferenceException("Connection Service is not initialized");
        }
        /// <summary>Returns the injected IChatRoom or throws if missing.</summary>
        public IChatRoom GetChatRoom()
        {
            return chatRoom ?? throw new NullReferenceException("Chat Room is not initialized");
        }
        /// <summary>Returns the injected IMessageProtocol or throws if missing.</summary>
        public IMessageProtocol GetMessageProtocol()
        {
            return protocol ?? throw new NullReferenceException("Message Protocol is not initialized");
        }
        /// <summary>Returns the injected IPeerDiscoveryService or throws if missing.</summary>
        public IPeerDiscoveryService GetPeerDiscoveryService()
        {
            return peerDiscovery ?? throw new NullReferenceException("Peer Discovery Service is not initialized");
        }
    }
}