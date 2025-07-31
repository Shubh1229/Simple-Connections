

using SimpleConnections.blueprints;
using SimpleConnections.model;
using SimpleConnections.pages.menu;
using SimpleConnections.tools;

namespace SimpleConnections.factory
{
    public class PageFactory : IFactory<PageModel>
    {
        private readonly PAGETYPE type;
        public PageModel Build()
        {
            switch (type)
            {
                case PAGETYPE.MAINMENU:
                    {
                        return MainMenuBuilder();
                    }
                default:
                    throw new NotImplementedException($"Feature for factory build type: {nameof(type)} is not implemented yet");
            }
            
        }

        private PageModel MainMenuBuilder()
        {
            Logger<MainMenu> logger = new();
            ChatRoom_v1 chatRoom = new();
            ConnectionService_v1 connection = new();
            LANDiscovery lan = new();
            MainMenuBackground background = new();
            MessageProtocol_v1 protocol = new();
            return new MainMenu(background, connection, chatRoom, logger, protocol, lan);
        }

        public PageFactory(PAGETYPE type)
        {
            this.type = type;
        }

    }
    public enum PAGETYPE
    {
        MAINMENU
    }
}