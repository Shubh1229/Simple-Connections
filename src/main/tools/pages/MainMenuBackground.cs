

namespace SimpleConnections.tools.pages
{
    using SimpleConnections.blueprints;
    using SimpleConnections.factory;
    using SimpleConnections.model;
    using SimpleConnections.resources;
    using Terminal.Gui;
    /// <summary>
    /// Specific implementation of BackgroundModel used for the Main Menu screen.
    /// Adds device-themed ASCII buttons, credits, and interactive navigation.
    /// </summary>
    public class MainMenuBackground : BackgroundModel
    {
        /// <summary>
        /// Builds the layout and visuals for the main menu including title art, button frame, 
        /// device buttons (PC, USB, Console, Apple), and navigation labels.
        /// </summary>
        public override Task BuildBackground(View container, PageModel page)
        {
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
                    BorderStyle = BorderStyle.Rounded,
                    Title = "Choose One...",
                    DrawMarginFrame = true,
                    BorderBrush = Color.BrightCyan,
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
                Y = Pos.AnchorEnd(8),
                Data = "exit",
                Text = exitbuttonText,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightGreen, background: Color.Red)
                },
                // Border = new Border()
                // {
                //     BorderBrush = Color.BrightMagenta,
                //     BorderStyle = BorderStyle.Single,
                // }
            };
            exitbutton.Clicked += () =>
            {
                ButtonPressed(ButtonType.Exit);
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
                    Normal = new Attribute(Color.BrightRed, Color.Black)
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
                    ButtonPressed(ButtonType.Usb);
                };
                pc.Clicked += () =>
                {
                    ButtonPressed(ButtonType.Pc);
                };
                console.Clicked += () =>
                {
                    ButtonPressed(ButtonType.Console);
                };
                apple.Clicked += () =>
                {
                    ButtonPressed(ButtonType.Apple);
                };
            }


            var collectionArt = GetArt(ART.COLLECTIONS);
            var connectionsbutton = new Label()
            {
                Width = 30,
                Height = 5,
                X = Pos.Center(),
                Y = Pos.Top(buttonView) - 4,
                Data = "Connections",
                Text = collectionArt,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme
                {
                    Normal = new Attribute(Color.BrightGreen, Color.Blue)
                },
                // Border = new Border()
                // {
                //     BorderBrush = Color.BrightMagenta,
                //     BorderStyle = BorderStyle.Single
                // },
            };
            connectionsbutton.Clicked += () =>
            {
                ButtonPressed(ButtonType.Connections, page);
            };
            var profileArt = GetArt(ART.PROFILE);
            var profilebutton = new Label()
            {
                Width = 20,
                X = Pos.Center(),
                Y = Pos.Center() + 3,
                Data = "profile",
                Text = profileArt,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.BrightGreen, background: Color.Magenta)
                },
                // Border = new Border()
                // {
                //     BorderBrush = Color.BrightMagenta,
                //     BorderStyle = BorderStyle.Single,
                // }
            };
            profilebutton.Clicked += () =>
            {
                ButtonPressed(ButtonType.Profile, page);
            };
            var chatroomArt = GetArt(ART.CHATROOM);
            var chatroombutton = new Label()
            {
                Width = 25,
                X = Pos.Center(),
                Y = Pos.Center() - 6,
                Data = "chatroom",
                Text = chatroomArt,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Attribute(foreground: Color.White, background: Color.Black)
                },
                // Border = new Border()
                // {
                //     BorderBrush = Color.BrightMagenta,
                //     BorderStyle = BorderStyle.Single,
                // }
            };
            chatroombutton.Clicked += () =>
            {
                ButtonPressed(ButtonType.ChatRoom, page);
            };

            // Add all labels and buttons into the main menu view
            {
                container.Add(label);
                buttonView.Add(exitbutton);
                buttonView.Add(apple);
                buttonView.Add(usb);
                buttonView.Add(console);
                buttonView.Add(pc);
                buttonView.Add(connectionsbutton);
                buttonView.Add(profilebutton);
                buttonView.Add(chatroombutton);
                container.Add(buttonView);
                container.Add(author);
                container.Add(contact);
            }

            return Task.CompletedTask;
        }
    }
}