using System.Windows;
using System.Windows.Input;

namespace SmallQyest.ViewModels
{
    /// <summary>
    /// View Model for the Main Menu.
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public MenuViewModel()
        {
            this.NewGame = new Command(param => this.OnNewGame());
            this.Exit = new Command(param => this.OnExit());
        }

        /// <summary>
        /// Starts new Game.
        /// </summary>
        private void OnNewGame()
        {
            base.AppController.ToLevel(1);
        }

        /// <summary>
        /// Exits the Application.
        /// </summary>
        private void OnExit()
        {
            base.Logger.LogMessage("Exiting the Application");
            Application.Current.MainWindow.Close();
        }

        #region Properties

        /// <summary>
        /// Retrieves the Command to start new Game.
        /// </summary>
        public ICommand NewGame { get; private set; }

        /// <summary>
        /// Retrieves the Command to exit Application.
        /// </summary>
        public ICommand Exit { get; private set; }

        #endregion

        #region Fields

        #endregion
    }
}
