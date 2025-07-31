

using SimpleConnections.blueprints;
using SimpleConnections.model;
using SimpleConnections.pages.connections;
using SimpleConnections.pages.menu;
using SimpleConnections.tools;
using SimpleConnections.tools.pages;

namespace SimpleConnections.factory
{
    public class PageFactory : IFactory<PageModel>
    {
        private readonly PAGETYPE type;
        private IChatRoom? chatRoom;
        private IConnectionService? connection;
        private IMessageProtocol? protocol;
        private IPeerDiscoveryService? peerDiscovery;
        private readonly Logger<PageFactory> logger_;
        private readonly CancellationToken token = new();
        public PageModel Build()
        {
            logger_.Log($"Building Main Menu off of Base Build() Method").WaitAsync(token);
            return MainMenuBuilder();
        }
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
                    throw new Exception("Type could not be identified.");
            }
        }

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

        private PageModel ConnectionsBuilder()
        {
            //throw new NotImplementedException();
            logger_.Log($"Building Connections Page...").WaitAsync(token);
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
        private bool CheckFieldsNull() {
            return chatRoom == null || connection == null || protocol == null || peerDiscovery == null;
        }
        public PageFactory(PAGETYPE type)
        {
            this.type = type;
            logger_ = new();
        }

    }
}