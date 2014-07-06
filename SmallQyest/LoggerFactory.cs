using Logging;

namespace SmallQyest
{
    /// <summary>
    /// Factory which creates Loggers.
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// Retrieves a Logger.
        /// </summary>
        /// <returns>Logger Instance.</returns>
        public ILogger GetLogger()
        {
            return new log4netLogger();
        }
    }
}
