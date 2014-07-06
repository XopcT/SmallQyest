using System.Runtime.CompilerServices;

namespace Logging
{
    /// <summary>
    /// Logger to write Messages to Output.
    /// </summary>
    public class OutputLogger : LoggerBase
    {
        /// <summary>
        /// Logs a Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// Logs an Error Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogError(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// Logs a Debug Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
