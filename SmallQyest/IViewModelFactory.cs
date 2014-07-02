
namespace SmallQyest
{
    /// <summary>
    /// Defines an Interface of a Factory which creates View Models.
    /// </summary>
    public interface IViewModelFactory
    {
        /// <summary>
        /// Retrieves View Model for Application main Menu.
        /// </summary>
        /// <returns>View Model Instance.</returns>
        IViewModel GetMainMenuViewModel();

        /// <summary>
        /// Retrieves View Model for a Game Level.
        /// </summary>
        /// <returns>View Model Instance.</returns>
        IViewModel GetLevelViewModel();
    }
}
