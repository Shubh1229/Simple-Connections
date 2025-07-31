


namespace SimpleConnections.pages.connections
{
    using System.Threading.Tasks;
    using SimpleConnections.blueprints;
    using SimpleConnections.model;
    using Terminal.Gui;

    /// <summary>
    /// UI page for managing peer-to-peer connections and local network presence.
    /// Contains a mock command-line terminal at the bottom for command testing.
    /// </summary>
    public class ConnectionsPage : PageModel
    {
        private readonly IBackground background;
        private readonly IConnectionService connection;
        private readonly IChatRoom chatRoom;
        private readonly ILogger logger;
        private readonly IMessageProtocol protocol;
        private readonly IPeerDiscoveryService peerDiscovery;
        private readonly CancellationToken token;

        /// <summary>Constructs the ConnectionsPage and injects required services.</summary>
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
        /// <summary>Builds UI components including a scrollable console-like terminal.</summary>
        public override void InitializeComponent()
        {
            var mockConsole = new FrameView("SimpleShell")
            {
                X = Pos.Center(),
                Y = Pos.AnchorEnd(12),
                Width = Dim.Fill(),
                Height = 12,
                ColorScheme = Colors.TopLevel,
                Border = new Border()
                {
                    BorderStyle = BorderStyle.Rounded,
                    BorderBrush = Color.BrightGreen,
                    DrawMarginFrame = true
                }
            };

            // Output area
            var outputBox = new TextView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(2),
                ReadOnly = true,
                WordWrap = true,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.BrightGreen, Color.Black)
                }
            };

            // Input field
            var inputBox = new TextField()
            {
                X = 0,
                Y = Pos.AnchorEnd(1),
                Width = Dim.Fill(),
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.White, Color.Black)
                }
            };

            // Command logic
            inputBox.KeyPress += (args) =>
            {
                if (args.KeyEvent.Key == Key.Enter)
                {
                    string command = inputBox.Text.ToString();
                    outputBox.Text += $"\n> {command}\n";

                    // Handle simple commands
                    if (command == "hello")
                        outputBox.Text += "[green]Hello there![/]\n";
                    else if (command == "help")
                        outputBox.Text += "[blue]Available: hello, help, clear[/]\n";
                    else if (command == "clear")
                        outputBox.Text = "";
                    else
                        outputBox.Text += "[red]Unknown command.[/]\n";

                    inputBox.Text = "";
                    args.Handled = true;
                }
                else
                {
                    inputBox.Text = inputBox.Text + args.KeyEvent.Key.ToString();
                }
            };

            mockConsole.Add(outputBox, inputBox);
            this.Add(mockConsole);
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill();
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
            //logger.Log("Initial Window Options Set -> Calling Connections Builder").WaitAsync(token);
            //background.BuildBackground(this, this).Wait(token);
        }
    }
}