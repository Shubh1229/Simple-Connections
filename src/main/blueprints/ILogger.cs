

namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Defines logging behavior for structured or timestamped message logging to file or output.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message asynchronously to a predefined log file.
        /// </summary>
        /// <param name="input">The message to be logged.</param>
        Task Log(string input);
    }
}