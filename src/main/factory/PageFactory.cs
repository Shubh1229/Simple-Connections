

using SimpleConnections.blueprints;
using SimpleConnections.model;
using SimpleConnections.pages.connections;
using SimpleConnections.pages.menu;
using SimpleConnections.tools;
using SimpleConnections.tools.pages;

namespace SimpleConnections.factory
{
    /// <summary>
    /// Responsible for constructing and returning different types of pages (MainMenu, Connections, etc.).
    /// Uses dependency injection when available, or falls back to new instances.
    /// </summary>
    public class PageFactory : IFactory<PageModel>
    {
        private readonly PAGETYPE type; // The page type to construct (MainMenu, Profile, etc.)
        private IChatRoom? chatRoom;    // Chat room dependency
        private IConnectionService? connection; // Network connection dependency
        private IMessageProtocol? protocol;     // Message encoder/decoder
        private IPeerDiscoveryService? peerDiscovery; // Peer discovery logic
        private readonly Logger<PageFactory> logger_; // Internal logger
        private readonly CancellationToken token = new(); // Cancellation token for async logging


        /// <summary>
        /// Builds a default Main Menu page using the base constructor.
        /// </summary>
        public PageModel Build()
        {
            logger_.Log($"Building Main Menu off of Base Build() Method").WaitAsync(token);
            return MainMenuBuilder();
        }


        /// <summary>
        /// Builds a page of the specified type using injected dependencies.
        /// </summary>
        public PageModel Build(IChatRoom chatRoom, IConnectionService connection, IMessageProtocol protocol, IPeerDiscoveryService peerDiscovery)
        {
            {
                this.chatRoom = chatRoom;
                this.connection = connection;
                this.protocol = protocol;
                this.peerDiscovery = peerDiscovery;
            }
            string nameType = NameOfType(type);
            logger_.Log($"Building new {nameType} page").WaitAsync(token);
            switch (type)
            {
                case PAGETYPE.MAINMENU:
                    {
                        return MainMenuBuilder();
                    }
                case PAGETYPE.CONNECTIONS:
                    {
                        return ConnectionsBuilder();
                    }
                case PAGETYPE.PROFILE:
                    {
                        return ProfileBuilder();
                    }
                case PAGETYPE.CHATROOM:
                    {
                        return ChatRoomBuilder();
                    }
                default:
                    throw new NotImplementedException($"Feature for factory build type: {nameof(type)} is not implemented yet");
            }

        }


        /// <summary>
        /// Returns a <c>string</c> for the name of the <c>PAGETYPE</c>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Page Type could not be identified.</exception>
        private string NameOfType(PAGETYPE type)
        {
            switch (type)
            {
                case PAGETYPE.MAINMENU:
                    return "MAINMENU";
                case PAGETYPE.CONNECTIONS:
                    return "CONNECTIONS";
                case PAGETYPE.PROFILE:
                    return "PROFILE";
                case PAGETYPE.CHATROOM:
                    return "CHATROOM";
                default:
                    throw new Exception("Page Type could not be identified.");
            }
        }

        /// <summary>
        /// Builds the Chat Room Page and returns it.
        /// <code>Application.Run(new PageFactory(PAGETYPE.CHATROOM));</code>
        /// </summary>
        /// <returns><c>ChatroomPage</c></returns>
        private PageModel ChatRoomBuilder()
        {
            throw new NotImplementedException();
            Logger<MainMenu> logger = new();
            MainMenuBackground background = new();
            if (CheckFieldsNull())
            {
                ChatRoom_v1 chatRoom = new();
                ConnectionService_v1 connection = new();
                LANDiscovery lan = new();
                MessageProtocol_v1 protocol = new();
                return new MainMenu(background, connection, chatRoom, logger, protocol, lan);
            }
            else
            {
                return new MainMenu(background, connection, chatRoom, logger, protocol, peerDiscovery);
            }
        }

        /// <summary>
        /// Builds the Profile Menu Page and returns it.
        /// <code>Application.Run(new PageFactory(PAGETYPE.PROFILE));</code>
        /// </summary>
        /// <returns><c>ProfilePage</c></returns>
        private PageModel ProfileBuilder()
        {
            throw new NotImplementedException();
            Logger<MainMenu> logger = new();
            MainMenuBackground background = new();
            if (CheckFieldsNull())
            {
                ChatRoom_v1 chatRoom = new();
                ConnectionService_v1 connection = new();
                LANDiscovery lan = new();
                MessageProtocol_v1 protocol = new();
                return new MainMenu(background, connection, chatRoom, logger, protocol, lan);
            }
            else
            {
                return new MainMenu(background, connection, chatRoom, logger, protocol, peerDiscovery);
            }
        }

        /// <summary>
        /// Builds the Connections Page and returns it.
        /// <code>Application.Run(new PageFactory(PAGETYPE.CONNECTIONS));</code>
        /// </summary>
        /// <returns><c>ConnectionsPage</c></returns>
        private PageModel ConnectionsBuilder()
        {
            logger_.Log($"Building Connections Page...").WaitAsync(token);
            Logger<ConnectionsPage> logger = new();
            MainMenuBackground background = new();
            if (CheckFieldsNull())
            {
                ChatRoom_v1 chatRoom = new();
                ConnectionService_v1 connection = new();
                LANDiscovery lan = new();
                MessageProtocol_v1 protocol = new();
                return new ConnectionsPage(background, connection, chatRoom, logger, protocol, lan);
            }
            else
            {
                return new ConnectionsPage(background, connection, chatRoom, logger, protocol, peerDiscovery);
            }
        }

        /// <summary>
        /// Builds the Main Menu Page and returns it.
        /// <code>Application.Run(new PageFactory(PAGETYPE.MAINMENU));</code>
        /// </summary>
        /// <returns><c>MainMenu</c></returns>
        private PageModel MainMenuBuilder()
        {
            logger_.Log($"Building Main Menu...").WaitAsync(token);
            Logger<MainMenu> logger = new();
            MainMenuBackground background = new();
            if (CheckFieldsNull())
            {
                logger_.Log($"Fields are NULL creating new dependencies").WaitAsync(token);
                ChatRoom_v1 chatRoom = new();
                ConnectionService_v1 connection = new();
                LANDiscovery lan = new();
                MessageProtocol_v1 protocol = new();
                return new MainMenu(background, connection, chatRoom, logger, protocol, lan);
            }
            else
            {
                logger_.Log($"Fields are not NULL carrying over previous dependencies").WaitAsync(token);
                return new MainMenu(background, connection, chatRoom, logger, protocol, peerDiscovery);
            }
        }
        /// <summary>
        /// Checks if any injected dependencies are missing (null).
        /// </summary>
        private bool CheckFieldsNull()
        {
            return chatRoom == null || connection == null || protocol == null || peerDiscovery == null;
        }
        public PageFactory(PAGETYPE type)
        {
            this.type = type;
            logger_ = new();
        }

    }
}