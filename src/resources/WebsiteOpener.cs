

using System.Diagnostics;

namespace SimpleConnections.resources
{
    public static class WebsiteOpener
    {
        private static readonly string usbweb = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley";
        private static readonly string pcweb = "https://www.reddit.com/media?url=https%3A%2F%2Fi.redd.it%2F1ffckd7mmrna1.jpg";
        private static readonly string consoleweb = "https://www.youtube.com/watch?v=B030fbyis7k&ab_channel=JoeFromSeattle";
        private static readonly string appleweb = "https://www.youtube.com/watch?v=v6025_yK02U&ab_channel=LouisRossmann";
        private static readonly OSType os = GetOSType();
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
    public enum Website
    {
        Usb, Apple, PC, Console
    }
    public enum OSType
    {
        Mac, Linux, Windows
    }
}