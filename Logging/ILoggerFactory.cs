
namespace Logging
{
    /// <summary>
    /// Defines an Interface of a Factory which creates Loggers.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Retrieves a Logger.
        /// </summary>
        /// <returns>Logger Instance.</returns>
        ILogger GetLogger();
    }
}
