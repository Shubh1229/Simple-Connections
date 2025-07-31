

namespace SimpleConnections.model
{
    using SimpleConnections.blueprints;

    /// <summary>
    /// Generic logger implementation that writes messages to a local log file with timestamps.
    /// </summary>
    /// <typeparam name="T">The class type calling the logger, used for source tagging.</typeparam>
    public class Logger<T> : ILogger
    {
        /// <summary>Path to the log file in the user profile directory.</summary>
        private readonly string FILEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".simpleconnections", "simpleconnections.log");
        /// <summary>Initializes the log directory if it doesn't exist.</summary>
        public Logger()
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".simpleconnections"));
        }
        /// <summary>Logs a message with timestamp and class name to the file asynchronously.</summary>
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