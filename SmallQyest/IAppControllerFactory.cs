
namespace SmallQyest
{
    /// <summary>
    /// Defines an Interface of a Factory which creates App Controller.
    /// </summary>
    public interface IAppControllerFactory
    {
        /// <summary>
        /// Retrieves the App Controller.
        /// </summary>
        /// <returns>App Controller Instance.</returns>
        IAppController GetAppController();
    }
}
