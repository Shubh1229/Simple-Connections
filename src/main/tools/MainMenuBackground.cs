

namespace SimpleConnections.tools
{
    using NStack;
    using SimpleConnections.blueprints;
    using Terminal.Gui;
    public class MainMenuBackground : IBackground
    {
        public Task BuildBackground(View container)
        {
            string text = @"
███████╗██╗███╗   ███╗██████╗ ██╗     ███████╗
██╔════╝██║████╗ ████║██╔══██╗██║     ██╔════╝
███████╗██║██╔████╔██║██████╔╝██║     █████╗
╚════██║██║██║╚██╔╝██║██╔═══╝ ██║     ██╔══╝
███████║██║██║ ╚═╝ ██║██║     ███████╗███████╗
╚══════╝╚═╝╚═╝     ╚═╝╚═╝     ╚══════╝╚══════╝
";
            string exitbuttonText = @"

░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░▒▓████████▓▒░
░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░  ░▒▓█▓▒░
░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░  ░▒▓█▓▒░
░▒▓██████▓▒░  ░▒▓██████▓▒░░▒▓█▓▒░  ░▒▓█▓▒░
░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░  ░▒▓█▓▒░
░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░  ░▒▓█▓▒░
░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░  ░▒▓█▓▒░
";

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
                Width = Dim.Percent(50), //Dim.Height(container)
                Height = Dim.Percent(50),
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
            var exitbutton = new Button()
            {
                Width = 20,
                X = Pos.Center(),
                Y = Pos.Percent(80),
                Data = "exit",
                //Text = exitbuttonText,
                Text = "EXIT",
                TextAlignment = TextAlignment.Justified,
                IsDefault = false,
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
                Y = 24,
                Title = "Made By",
                TextAlignment = TextAlignment.Left,
                Width = Dim.Percent(15), //Dim.Height(container)
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
                Text = "Arihant Singh",
                TextFormatter = new TextFormatter()
                {
                    AutoSize = true
                }
            };
            author.Add(new Label("Arihant Singh") { X = 1, Y = 0 });




            container.Add(label);
            buttonView.Add(exitbutton);
            container.Add(buttonView);
            container.Add(author);

            return Task.CompletedTask;
        }
    }
}