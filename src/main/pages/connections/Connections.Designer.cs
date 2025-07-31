


namespace SimpleConnections.pages.connections
{
    using System.Threading.Tasks;
    using SimpleConnections.blueprints;
    using SimpleConnections.model;

    public class ConnectionsPage : PageModel
    {
        private readonly IBackground background;
        private readonly IConnectionService connection;
        private readonly IChatRoom chatRoom;
        private readonly ILogger logger;
        private readonly IMessageProtocol protocol;
        private readonly IPeerDiscoveryService peerDiscovery;
        private readonly CancellationToken token;

        public ConnectionsPage(IBackground background, IConnectionService connection,
        IChatRoom chatRoom, ILogger logger, IMessageProtocol messageProtocol, IPeerDiscoveryService peerDiscovery)
            : base("Simple Connections", background, connection, logger, messageProtocol, peerDiscovery, chatRoom)
        {
            this.background = background;
            this.connection = connection;
            this.logger = logger;
            this.protocol = messageProtocol;
            this.peerDiscovery = peerDiscovery;
            this.chatRoom = chatRoom;
            this.token = new();
            InitializeComponent();
        }
        public override void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}