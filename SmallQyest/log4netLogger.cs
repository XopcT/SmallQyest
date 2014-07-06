using log4net;
using Logging;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace SmallQyest
{
    /// <summary>
    /// Logger to write Messages via log4net.
    /// </summary>
    public class log4netLogger : LoggerBase
    {
        /// <summary>
        /// Logs a Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogMessage(string message)
        {
            this.logger.Debug(message);
        }

        /// <summary>
        /// Logs an Error Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogError(string message)
        {
            base.LogError(message);
        }

        /// <summary>
        /// Logs a Debug Message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public override void LogDebug(string message)
        {
            base.LogDebug(message);
        }

        #region Properties

        #endregion

        #region Fields
        private ILog logger = LogManager.GetLogger("default");

        #endregion
    }
}
