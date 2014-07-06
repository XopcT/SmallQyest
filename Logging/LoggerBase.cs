
namespace Logging
{
    /// <summary>
    /// Base Class for creating Loggers.
    /// </summary>
    public class LoggerBase : ILogger
    {
        /// <summary>
        /// Logs a Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public virtual void LogMessage(string message)
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Logs formatted Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        public void LogMessage(string format, params object[] args)
        {
            this.LogMessage(string.Format(format, args));
        }

        /// <summary>
        /// Logs an Error Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public virtual void LogError(string message)
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Logs formatted Error Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        public void LogError(string format, params object[] args)
        {
            this.LogError(string.Format(format, args));
        }

        /// <summary>
        /// Logs a Debug Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public virtual void LogDebug(string message)
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Logs formatted Debug Message.
        /// </summary>
        /// <param name="format">Format of the Message.</param>
        /// <param name="args">Arguments to format.</param>
        public void LogDebug(string format, params object[] args)
        {
            this.LogDebug(string.Format(format, args));
        }
    }
}
