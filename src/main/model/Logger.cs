

namespace SimpleConnections.model
{
    using System.Diagnostics;
    using SimpleConnections.blueprints;
    using Spectre.Console;

    public class Logger<T> : ILogger
    {
        private readonly string FILEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".simpleconnections", "simpleconnections.log");
        public Logger()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".simpleconnections"));
        }
        public async Task Log(string input)
        {
            using var stream = new FileStream(FILEPATH, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            using StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            input = string.IsNullOrWhiteSpace(input) ? "No message provided" : input;
            DateTime now = DateTime.Now;
            string name = typeof(T).Name;
            string write = $"[{now}] [{name}] {input}";
            await writer.WriteLineAsync(write);
            await writer.FlushAsync();
        }
    }
}