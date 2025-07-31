
using SimpleConnections.blueprints;
using SimpleConnections.factory;
using SimpleConnections.resources;
using Terminal.Gui;

namespace SimpleConnections.model
{
    public abstract class BackgroundModel : IBackground
    {
        private static readonly Logger<BackgroundModel> logger = new();
        private static readonly CancellationToken token = new();
        public abstract Task BuildBackground(View container, PageModel page);
        public void ButtonPressed(ButtonType button)
        {
            logger.Log($"Button {ButtonPressedName(button)} Is Being Executed...").WaitAsync(token);
            switch (button)
            {
                case ButtonType.Pc:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case ButtonType.Apple:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case ButtonType.Console:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case ButtonType.Usb:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case ButtonType.Exit:
                    {
                        Console.Clear();
                        Application.RequestStop();
                        break;
                    }
                default:
                    throw new Exception($"{nameof(button)} is not a valid button");
            }
        }
        private string ButtonPressedName(ButtonType button)
        {
            switch (button)
            {
                case ButtonType.Exit:
                    return "EXIT";
                case ButtonType.Connections:
                    return "CONNECTIONS";
                case ButtonType.Profile:
                    return "PROFILE";
                case ButtonType.ChatRoom:
                    return "CHATROOM";
                case ButtonType.Apple:
                    return "APPLE";
                case ButtonType.Console:
                    return "CONSOLE";
                case ButtonType.Pc:
                    return "PC";
                case ButtonType.Usb:
                    return "USB";
                case ButtonType.MainMenu:
                    return "MAINMENU";
                default:
                    throw new Exception($"Could not find button {button}");
            }
        }
        public void ButtonPressed(ButtonType button, PageModel page)
        {
            if (page == null) throw new NullReferenceException("Page is never initialized");
            switch (button)
            {
                case ButtonType.Connections:
                    {
                        SwitchPage(PAGETYPE.CONNECTIONS, page);
                        break;
                    }
                case ButtonType.Exit:
                    {
                        Application.RequestStop();
                        break;
                    }
                case ButtonType.Profile:
                    {
                        SwitchPage(PAGETYPE.PROFILE, page);
                        break;
                    }
                case ButtonType.ChatRoom:
                    {
                        SwitchPage(PAGETYPE.CHATROOM, page);
                        break;
                    }
                case ButtonType.MainMenu:
                    {
                        SwitchPage(PAGETYPE.MAINMENU, page);
                        break;
                    }
                default:
                    throw new Exception($"{nameof(button)} is not a valid button");
            }
        }
        public string GetArt(ART art)
        {
            switch (art)
            {
                case ART.EXIT:
                    {
                        return
@"
░        ░░  ░░░░  ░░        ░░        ░
▒  ▒▒▒▒▒▒▒▒▒  ▒▒  ▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒  ▒▒▒▒
▓      ▓▓▓▓▓▓    ▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓  ▓▓▓▓
█  █████████  ██  ██████  ████████  ████
█        ██  ████  ██        █████  ████
";
                    }
                case ART.TITLE:
                    {
                        return
@"
███████╗██╗███╗   ███╗██████╗ ██╗     ███████╗
██╔════╝██║████╗ ████║██╔══██╗██║     ██╔════╝
███████╗██║██╔████╔██║██████╔╝██║     █████╗
╚════██║██║██║╚██╔╝██║██╔═══╝ ██║     ██╔══╝
███████║██║██║ ╚═╝ ██║██║     ███████╗███████╗
╚══════╝╚═╝╚═╝     ╚═╝╚═╝     ╚══════╝╚══════╝
";
                    }
                case ART.APPLE:
                    {
                        return
@"
           .:'
      __ :'__
   .'`__`-'__``.
  :__________.-'
  :_________:
   :_________`-;
    `.__.-.__.'
";
                    }
                case ART.CONSOLE:
                    {
                        return
@"
     []  ,----.___
   __||_/___      '.
  / O||    /|       )
 /   ""   / /   =._/
/________/ /
|________|/
";
                    }
                case ART.PC:
                    {
                        return
@"
              .----.
  .---------. | == |
  |.-""""""""""-.| |----|
  ||       || | == |
  ||       || |----|
  |'-.....-'| |::::|
  `"""")---(""""` |___.|
 /:::::::::::\"" _  ""
/:::=======:::\`\`\
`""""""""""""""`  '-'
";
                    }
                case ART.USB:
                    {
                        return
@"
   _   ,--()
  ( )-'-.------|>
   ""     `--[]
";
                    }
                case ART.COLLECTIONS:
                    {
                        return
@"
░░      ░░░░      ░░░   ░░░  ░░   ░░░  ░░        ░░░      ░░░        ░░        ░░░      ░░░   ░░░  ░░░      ░░
▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒    ▒▒  ▒▒    ▒▒  ▒▒  ▒▒▒▒▒▒▒▒  ▒▒▒▒  ▒▒▒▒▒  ▒▒▒▒▒▒▒▒  ▒▒▒▒▒  ▒▒▒▒  ▒▒    ▒▒  ▒▒  ▒▒▒▒▒▒▒
▓  ▓▓▓▓▓▓▓▓  ▓▓▓▓  ▓▓  ▓  ▓  ▓▓  ▓  ▓  ▓▓      ▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓  ▓▓  ▓  ▓  ▓▓▓      ▓▓
█  ████  ██  ████  ██  ██    ██  ██    ██  ████████  ████  █████  ████████  █████  ████  ██  ██    ████████  █
██      ████      ███  ███   ██  ███   ██        ███      ██████  █████        ███      ███  ███   ███      ██
";
                    }
                case ART.PROFILE:
                    {
                        return
@"
░       ░░░       ░░░░      ░░░        ░░        ░░  ░░░░░░░░        ░
▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒  ▒▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒  ▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒▒
▓       ▓▓▓       ▓▓▓  ▓▓▓▓  ▓▓      ▓▓▓▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓▓▓▓      ▓▓▓
█  ████████  ███  ███  ████  ██  ███████████  █████  ████████  ███████
█  ████████  ████  ███      ███  ████████        ██        ██        █
";
                    }
                case ART.CHATROOM:
                    {
                        return
@"
░░      ░░░  ░░░░  ░░░      ░░░        ░░       ░░░░      ░░░░      ░░░  ░░░░  ░
▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒▒▒▒  ▒▒▒▒▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒  ▒▒▒▒  ▒▒   ▒▒   ▒
▓  ▓▓▓▓▓▓▓▓        ▓▓  ▓▓▓▓  ▓▓▓▓▓  ▓▓▓▓▓       ▓▓▓  ▓▓▓▓  ▓▓  ▓▓▓▓  ▓▓        ▓
█  ████  ██  ████  ██        █████  █████  ███  ███  ████  ██  ████  ██  █  █  █
██      ███  ████  ██  ████  █████  █████  ████  ███      ████      ███  ████  █
";
                    }
                default:
                    throw new Exception("How did you even get here?");
            }
        }
        private void SwitchPage(PAGETYPE type, PageModel page)
        {
            PageFactory pageFactory = new PageFactory(type);
            var newpage = pageFactory.Build(page.GetChatRoom(), page.GetConnectionService(), page.GetMessageProtocol(), page.GetPeerDiscoveryService());
            Application.RequestStop();
            Application.Run(newpage);
        }
    }
}