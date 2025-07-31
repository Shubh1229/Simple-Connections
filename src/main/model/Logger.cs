

namespace SimpleConnections.model
{
    using SimpleConnections.blueprints;
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
            await writer.WriteLineAsync($"[{DateTime.Now}] [{typeof(T).Name}] {input}");
            await writer.FlushAsync();
        }
    }
}