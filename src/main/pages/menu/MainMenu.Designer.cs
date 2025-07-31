

namespace SimpleConnections.pages.menu
{
    using System;
    using SimpleConnections.blueprints;
    using SimpleConnections.model;
    using Terminal.Gui;
    /// <summary>
    /// Initial entry screen for the app, displays device art, credits, and navigation buttons.
    /// </summary>
    public class MainMenu : PageModel
    {
        private readonly IBackground background;
        private readonly IConnectionService connection;
        private readonly IChatRoom chatRoom;
        private readonly ILogger logger;
        private readonly IMessageProtocol protocol;
        private readonly IPeerDiscoveryService peerDiscovery;
        private readonly CancellationToken token;

        /// <summary>Constructs the Main Menu and injects required services.</summary>
        public MainMenu(IBackground background, IConnectionService connection,
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
        /// <summary>Builds the menu UI, background art, and routing buttons.</summary>
        public override void InitializeComponent()
        {
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Text = "";
            this.Border.BorderStyle = BorderStyle.Single;
            this.Border.Effect3D = true;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = TextAlignment.Left;
            this.ColorScheme = new ColorScheme()
            {
                Normal = new Terminal.Gui.Attribute(foreground: Color.BrightGreen, background: Color.Black)
            };
            logger.Log("Initial Window Options Set -> Calling Background Builder").WaitAsync(token);
            background.BuildBackground(this, this).Wait(token);
        }

    }
}