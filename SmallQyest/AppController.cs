using SmallQyest.Core;
using Logging;

namespace SmallQyest
{
    /// <summary>
    /// View Model for the Application.
    /// </summary>
    public class AppController : BindableBase, IAppController
    {
        /// <summary>
        /// Navigates to the main Menu.
        /// </summary>
        public void ToMainMenu()
        {
            this.Logger.LogMessage("Navigating to Main Menu");
            this.CurrentScreen = this.ViewModelFactory.GetMainMenuViewModel();
        }

        /// <summary>
        /// Navigates to the Level Select Menu.
        /// </summary>
        public void ToLevelSelect()
        {
            this.Logger.LogMessage("Navigating to Level Selection");
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Navigates to the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the desired Level.</param>
        public void ToLevel(int levelId)
        {
            this.Logger.LogMessage("Navigating to Level {0}", levelId);
            Level level = this.LevelFactory.LoadLevel(levelId);
            this.CurrentScreen = this.ViewModelFactory.GetLevelViewModel(level);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Application Screen.
        /// </summary>
        public IViewModel CurrentScreen
        {
            get { return this.currentScreen; }
            set
            {
                if (this.currentScreen != null)
                    this.currentScreen.OnNavigateFrom();

                this.currentScreen = value;
                base.OnPropertyChanged(this);

                if (this.currentScreen != null)
                    this.currentScreen.OnNavigateTo();
            }
        }

        /// <summary>
        /// Sets/retrieves the Factory to create View Models.
        /// </summary>
        public IViewModelFactory ViewModelFactory { get; set; }

        /// <summary>
        /// Sets/retrieves the Factory to create Levels.
        /// </summary>
        public ILevelFactory LevelFactory { get; set; }

        /// <summary>
        /// Sets/retrieves the Logger for App Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields

        private IViewModel currentScreen = null;

        #endregion
    }
}
