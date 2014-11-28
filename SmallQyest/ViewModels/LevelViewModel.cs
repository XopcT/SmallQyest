using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using SmallQyest.World;
using SmallQyest.World.Characters;
using SmallQyest.World.Things;
using SmallQyest.World.Tiles;

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
            this.Start = new Command(arg => this.OnStart());
            this.Restart = new Command(arg => this.OnRestart());

            this.timer = new DispatcherTimer();
            this.timer.Tick += timer_Tick;
            this.timer.Interval = TimeSpan.FromSeconds(0.3);
        }

        /// <summary>
        /// Performs the main Level Activity.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.level.Map.Update();
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
        public override void OnNavigateTo()
        {
            base.OnNavigateTo();

            this.Level.LevelPassed += this.Level_LevelPassed;
            this.Level.LevelFailed += this.Level_LevelFailed;
        }

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        public override void OnNavigateFrom()
        {
            base.OnNavigateFrom();

            this.timer.Stop();

            this.Level.LevelPassed -= this.Level_LevelPassed;
            this.Level.LevelFailed -= this.Level_LevelFailed;
        }

        /// <summary>
        /// Handles going back from the Level.
        /// </summary>
        private void OnBack()
        {
            this.timer.Stop();
            base.AppController.ToMainMenu();
        }

        /// <summary>
        /// Handles starting the Level.
        /// </summary>
        private void OnStart()
        {
            this.timer.Start();
        }

        /// <summary>
        /// Handles restarting the Level.
        /// </summary>
        private void OnRestart()
        {
            this.timer.Stop();
            this.level.Reset();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Level.
        /// </summary>
        public ILevel Level
        {
            get { return this.level; }
            set
            {
                this.level = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Retrieves a Command to go Back from the Level.
        /// </summary>
        public ICommand Back { get; private set; }

        /// <summary>
        /// Retrieves a Command to start the Level.
        /// </summary>
        public ICommand Start { get; private set; }

        /// <summary>
        /// Retrieves a Command to restart the Level.
        /// </summary>
        public ICommand Restart { get; private set; }

        #endregion

        #region Fields
        private ILevel level = null;
        private DispatcherTimer timer = null;

        #endregion
    }
}
