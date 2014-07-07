using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SmallQyest.Core;
using SmallQyest.Models;

namespace SmallQyest.ViewModels
{
    /// <summary>
    /// View Model for a Game Level.
    /// </summary>
    public class LevelViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public LevelViewModel()
        {
            this.Back = new Command(arg => this.OnBack());
            this.Restart = new Command(arg => this.OnRestart());
        }

        /// <summary>
        /// Performs the main Level Activity.
        /// </summary>
        /// <param name="cancel">Triggers the exiting the Level.</param>
        private async void MainLoop(CancellationToken cancel)
        {
            base.Logger.LogMessage("Level Loop started.");
            while (!cancel.IsCancellationRequested)
            {
                this.levelWrapper.Update();
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
            base.Logger.LogMessage("Level Loop exited");
        }

        /// <summary>
        /// Handles passing the Level.
        /// </summary>
        private void Level_LevelPassed(object sender, LevelPassedEventArgs e)
        {
            base.AppController.ToLevel(e.NextLevel);
        }

        /// <summary>
        /// Handles failing the Level.
        /// </summary>
        private void Level_LevelFailed(object sender, EventArgs e)
        {
            this.OnRestart();
        }

        /// <summary>
        /// Handles Navigation to this View Model.
        /// </summary>
        public override async void OnNavigateTo()
        {
            base.OnNavigateTo();

            this.Level.LevelPassed += this.Level_LevelPassed;
            this.Level.LevelFailed += this.Level_LevelFailed;

            await Task.Run(() => this.MainLoop(this.cancel.Token), this.cancel.Token);
        }

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        public override void OnNavigateFrom()
        {
            base.OnNavigateFrom();

            this.cancel.Cancel();

            this.Level.LevelPassed -= this.Level_LevelPassed;
            this.Level.LevelFailed -= this.Level_LevelFailed;
        }

        /// <summary>
        /// Handles going back from the Level.
        /// </summary>
        private void OnBack()
        {
            this.cancel.Cancel();
            base.AppController.ToMainMenu();
        }

        /// <summary>
        /// Handles restarting the Level.
        /// </summary>
        private void OnRestart()
        {
            this.levelWrapper.Wrapped.Initialize();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Level.
        /// </summary>
        public ILevel Level
        {
            get { return this.levelWrapper.Wrapped; }
            set
            {
                this.levelWrapper = new LevelWrapper(value);

                base.OnPropertyChanged(this);
                base.OnPropertyChanged(this, "GroundTiles");
                base.OnPropertyChanged(this, "Characters");
            }
        }

        /// <summary>
        /// Retrieves the Ground Tiles of the Map.
        /// </summary>
        public IEnumerable<TileWrapper> Tiles
        {
            get { return this.levelWrapper.Tiles; }
        }

        /// <summary>
        /// Retrieves the Characters of the Map.
        /// </summary>
        public IEnumerable<CharacterWrapper> Characters
        {
            get { return this.levelWrapper.Characters; }
        }

        /// <summary>
        /// Retrieves a Command to go Back from the Level.
        /// </summary>
        public ICommand Back { get; private set; }

        /// <summary>
        /// Retrieves a Command to restart the Level.
        /// </summary>
        public ICommand Restart { get; private set; }

        #endregion

        #region Fields
        private LevelWrapper levelWrapper = null;

        private CancellationTokenSource cancel = new CancellationTokenSource();

        #endregion
    }
}
