using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmallQyest.Core;

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
            this.CurrentScreen = this.ViewModelFactory.GetMainMenuViewModel();
        }

        /// <summary>
        /// Navigates to the Level Select Menu.
        /// </summary>
        public void ToLevelSelect()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Navigates to the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the desired Level.</param>
        public void ToLevel(int levelId)
        {
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

        #endregion

        #region Fields

        private IViewModel currentScreen = null;

        #endregion
    }
}
