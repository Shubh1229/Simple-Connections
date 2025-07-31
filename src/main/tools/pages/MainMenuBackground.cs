

namespace SimpleConnections.tools.pages
{
    using SimpleConnections.blueprints;
    using SimpleConnections.factory;
    using SimpleConnections.model;
    using SimpleConnections.resources;
    using Terminal.Gui;
    public class MainMenuBackground : IBackground
    {
        private PageModel page;
        public Task BuildBackground(View container, PageModel page)
        {
            this.page = page;
            var text = GetArt(art: ART.TITLE);
            var label = new Label()
            {
                Data = "label",
                Text = text,
                X = Pos.Center(),
                Y = Pos.Top(container),
                Width = 1,
                Height = text.Split('\n').Length,
                TextAlignment = TextAlignment.Left
            };
            label.ColorScheme = new ColorScheme()
            {
                Normal = new Attribute(foreground: Color.BrightGreen)
            };

            var buttonView = new FrameView()
            {
                Data = "Button Frame",
                X = Pos.Center(),
                Y = 9,
                Title = "Select One",
                Width = Dim.Percent(80),
                Height = Dim.Percent(70),
                Border = new Border()
                {
                    BorderStyle = BorderStyle.Double,
                    DrawMarginFrame = true
                },
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightGreen, background: Color.Black)
                }
            };
            var exitbuttonText = GetArt(ART.EXIT);
            var exitbutton = new Label()
            {
                Width = 20,
                X = Pos.Center(),
                Y = Pos.AnchorEnd(10),
                Data = "exit",
                Text = exitbuttonText,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightGreen, background: Color.Red)
                },
                Border = new Border()
                {
                    BorderBrush = Color.BrightMagenta,
                    BorderStyle = BorderStyle.Single,
                }
            };
            exitbutton.Clicked += () =>
            {
                Application.RequestStop();
            };


            var author = new FrameView("Made By", new Border()
            {
                BorderBrush = Color.BrightCyan,
                BorderStyle = BorderStyle.Rounded,
                BorderThickness = new Thickness(3),
            })
            {
                Data = "Author Frame",
                X = Pos.Center(),
                Y = Pos.Bottom(buttonView) + 1,
                Title = "Made By",
                TextAlignment = TextAlignment.Centered,
                Width = Dim.Percent(25), //Dim.Height(container)
                Height = Dim.Percent(5),
                Border = new Border()
                {
                    BorderStyle = BorderStyle.Double,
                    DrawMarginFrame = true
                },
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightGreen, background: Color.Black)
                },
                Text = "Made By Arihant Singh",
                TextFormatter = new TextFormatter()
                {
                    AutoSize = true
                }
            };

            var contact = new Label(@"
Git Hub: https://github.com/Shubh1229
Email: shubh610@gmail.com
Website: https://ccflock.duckdns.org
            ")
            {
                X = Pos.AnchorEnd(40),
                Y = Pos.AnchorEnd(5),
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightMagenta, background: Color.Black)
                }
            };

            var appleArt = GetArt(ART.APPLE);
            var apple = new Label()
            {
                Text = appleArt,
                X = Pos.Center() + 60,
                Y = Pos.Center() - 20,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.Red, Color.Black)
                }
            };
            var consoleArt = GetArt(ART.CONSOLE);
            var console = new Label()
            {
                Text = consoleArt,
                X = Pos.Center() + 59,
                Y = Pos.Center() + 12,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.BrightCyan, Color.Black)
                }
            };
            var pcArt = GetArt(ART.PC);
            var pc = new Label()
            {
                Text = pcArt,
                X = Pos.Center() - 80,
                Y = Pos.Center() + 8,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.BrightMagenta, Color.Black)
                }
            };
            var usbArt = GetArt(ART.USB);
            var usb = new Label()
            {
                Text = usbArt,
                X = Pos.Center() - 80,
                Y = Pos.Center() - 20,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(Color.White, Color.Black)
                }
            };

            // give all labels their function when clicked
            {
                usb.Clicked += () =>
                {
                    ButtonPressed(Button.Usb);
                };
                pc.Clicked += () =>
                {
                    ButtonPressed(Button.Pc);
                };
                console.Clicked += () =>
                {
                    ButtonPressed(Button.Console);
                };
                apple.Clicked += () =>
                {
                    ButtonPressed(Button.Apple);
                };
            }


            /*
                TODO:
                    All these buttons need to be added to the main menu view
                    They also need to initialize new views as well.
            */
            {
                var connectionsbutton = new Button() { };
                var profilebutton = new Button() { };
                var chatroombutton = new Button() { };
                {
                    /*
                        Also note this below
                        PageFactory pageFactory = new PageFactory(PAGETYPE.CONNECTIONS);
                        pageFactory.Build(page.GetChatRoom(), page.GetConnectionService(), page.GetMessageProtocol(), page.GetPeerDiscoveryService());
                    */
                }
            }
            // Add all labels and buttons into the main menu view
            {
                container.Add(label);
                buttonView.Add(exitbutton);
                buttonView.Add(apple);
                buttonView.Add(usb);
                buttonView.Add(console);
                buttonView.Add(pc);
                container.Add(buttonView);
                container.Add(author);
                container.Add(contact);
            }

            return Task.CompletedTask;
        }

        private void ButtonPressed(Button button)
        {
            switch (button)
            {
                case Button.Pc:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case Button.Apple:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case Button.Console:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case Button.Usb:
                    {
                        WebsiteOpener.Run(Website.PC).WaitAsync(new CancellationToken());
                        Application.RequestStop();
                        break;
                    }
                case Button.Connections:
                    {
                        PageFactory pageFactory = new PageFactory(PAGETYPE.CONNECTIONS);
                        pageFactory.Build(page.GetChatRoom(), page.GetConnectionService(), page.GetMessageProtocol(), page.GetPeerDiscoveryService());
                        break;
                    }
                case Button.Exit:
                    {
                        Application.RequestStop();
                        break;
                    }
                case Button.Profile:
                    {
                        PageFactory pageFactory = new PageFactory(PAGETYPE.PROFILE);
                        pageFactory.Build(page.GetChatRoom(), page.GetConnectionService(), page.GetMessageProtocol(), page.GetPeerDiscoveryService());
                        break;
                    }
                case Button.ChatRoom:
                    {
                        PageFactory pageFactory = new PageFactory(PAGETYPE.CHATROOM);
                        pageFactory.Build(page.GetChatRoom(), page.GetConnectionService(), page.GetMessageProtocol(), page.GetPeerDiscoveryService());
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
                default:
                    throw new Exception("How did you even get here?");
            }
        }
    }
    public enum ART
    {
        EXIT, APPLE, CONSOLE, PC, USB, TITLE
    }
    public enum Button
    {
        Exit, Connections, Profile, ChatRoom, Apple, Console, Pc, Usb
    }
}