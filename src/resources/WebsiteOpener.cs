

using System.Diagnostics;
using SimpleConnections.model;

namespace SimpleConnections.resources
{
    /// <summary>
    /// Opens URLs in the default system browser based on the host operating system.
    /// Used to open device-themed media when selecting buttons in the UI.
    /// </summary>
    public static class WebsiteOpener
    {
        private static readonly string usbweb = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley"; // Get Rick Rolled Loser ;)
        private static readonly string pcweb = "https://www.reddit.com/media?url=https%3A%2F%2Fi.redd.it%2F1ffckd7mmrna1.jpg"; // PC is wayyy better
        private static readonly string consoleweb = "https://www.youtube.com/watch?v=B030fbyis7k&ab_channel=JoeFromSeattle"; // Trolling Console Users
        private static readonly string appleweb = "https://www.youtube.com/watch?v=v6025_yK02U&ab_channel=LouisRossmann"; // Trolling Mac Users
        private static readonly OSType os = GetOSType();
        /// <summary>
        /// Asynchronously opens the corresponding website for the given device type.
        /// </summary>
        public static Task Run(Website website)
        {
            Task.Run(() =>
            {
                string web = GetWebsite(website);
                switch (os)
                {
                    case OSType.Mac:
                        {
                            Process.Start("open", web);
                            break;
                        }
                    case OSType.Linux:
                        {
                            Process.Start("xdg-open", web);
                            break;
                        }
                    case OSType.Windows:
                        {
                            Process.Start(new ProcessStartInfo("cmd", $"/c start {web}")
                            {
                                CreateNoWindow = true,
                                UseShellExecute = true
                            });
                            break;
                        }
                    default:
                        throw new Exception($"Cannot find Process to run website {web} using OS Type {nameof(os)}");
                }
            });
            return Task.CompletedTask;
        }

        /// <summary>
        /// Resolves the target URL for a specific Website enum value.
        /// </summary>
        private static string GetWebsite(Website website)
        {
            switch (website)
            {
                case Website.Usb:
                    {
                        return usbweb;
                    }
                case Website.Apple:
                    {
                        return appleweb;
                    }
                case Website.PC:
                    {
                        return pcweb;
                    }
                case Website.Console:
                    {
                        return consoleweb;
                    }
                default:
                    throw new Exception($"Could not find website {nameof(website)}");
            }
        }

        /// <summary>
        /// Returns the OS-specific terminal command string used to launch a browser.
        /// </summary>
        public static OSType GetOSType()
        {
            if (OperatingSystem.IsWindows())
            {
                return OSType.Windows;
            }
            else if (OperatingSystem.IsMacOS())
            {
                return OSType.Mac;
            }
            else if (OperatingSystem.IsLinux())
            {
                return OSType.Linux;
            }
            else
            {
                throw new Exception("Unknown OS Type");
            }
        }
    }
}