
namespace SmallQyest
{
    /// <summary>
    /// Defines an Interface of App Controller.
    /// </summary>
    public interface IAppController
    {
        /// <summary>
        /// Navigates to main Menu.
        /// </summary>
        void ToMainMenu();

        /// <summary>
        /// Navigates to the Level Select Menu.
        /// </summary>
        void ToLevelSelect();

        /// <summary>
        /// Navigates to the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the desired Level.</param>
        void ToLevel(int levelId);

        /// <summary>
        /// Sets/retrieves the current Application Screen.
        /// </summary>
        IViewModel CurrentScreen { get; set; }
    }
}
