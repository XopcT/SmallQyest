
namespace Logging
{
    /// <summary>
    /// Defines an Interface to log Application Messages.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogMessage(string message);

        /// <summary>
        /// Logs formatted Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        void LogMessage(string format, params object[] args);

        /// <summary>
        /// Logs an Error Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogError(string message);

        /// <summary>
        /// Logs formatted Error Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        void LogError(string format, params object[] args);

        /// <summary>
        /// Logs a Debug Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogDebug(string message);

        /// <summary>
        /// Logs formatted Debug Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        void LogDebug(string format, params object[] args);
    }
}
