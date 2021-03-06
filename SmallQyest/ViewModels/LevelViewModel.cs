﻿using System;
using System.Linq;
using System.Windows.Input;
using SmallQyest.World;
using SmallQyest.World.Things;

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
            this.Stop = new Command(arg => this.OnStop());
            this.Reset = new Command(arg => this.OnReset());
            this.MoveToToolbar = new Command(arg => this.OnMoveToToolbar((dynamic)arg));
            this.MoveToMap = new Command(arg => this.OnMoveToMap((dynamic)arg));
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

            this.level.Stop();
            this.Level.LevelPassed -= this.Level_LevelPassed;
            this.Level.LevelFailed -= this.Level_LevelFailed;
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
            this.level.Stop();
        }

        /// <summary>
        /// Performs the main Level Activity.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.level.Map.Update();
        }

        /// <summary>
        /// Handles starting the Level.
        /// </summary>
        private void OnStart()
        {
            this.level.Start();
        }

        /// <summary>
        /// Handles stopping the Level.
        /// </summary>
        private void OnStop()
        {
            this.level.Stop();
        }

        /// <summary>
        /// Handles resetting the Level.
        /// </summary>
        private void OnReset()
        {
            this.level.Reset();
        }

        /// <summary>
        /// Handles going back from the Level.
        /// </summary>
        private void OnBack()
        {
            this.level.Stop();
            base.AppController.ToMainMenu();
        }

        /// <summary>
        /// Handles moving an Object to the Toolbar.
        /// </summary>
        private void OnMoveToToolbar(dynamic param)
        {
            Thing thing = param.Source;
            this.level.Tools.Add(thing);
            this.level.Map.Remove(thing);
        }

        /// <summary>
        /// Handles moving an Object to the Map.
        /// </summary>
        private void OnMoveToMap(dynamic param)
        {
            Thing thing = param.Source;
            Item target = param.Target as Item;
            if (target == null)
                return;
            bool canPutOnTarget = !this.level.Map.GetItems<Thing>(target.Position).Any();
            if (canPutOnTarget)
            {
                thing.Position = target.Position;
                this.level.Map.Add(thing);
                bool removed = this.level.Tools.Remove(thing);
            }
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
        /// Retrieves a Command to stop the Level.
        /// </summary>
        public ICommand Stop { get; private set; }

        /// <summary>
        /// Retrieves a Command to restart the Level.
        /// </summary>
        public ICommand Restart { get; private set; }

        /// <summary>
        /// Retrieves a Command to reset the Level.
        /// </summary>
        public ICommand Reset { get; private set; }

        /// <summary>
        /// Retrieves a Command to move an Object to the Toolbar.
        /// </summary>
        public ICommand MoveToToolbar { get; private set; }

        /// <summary>
        /// Retrieves a Command to move an Object to the Map.
        /// </summary>
        public ICommand MoveToMap { get; private set; }

        #endregion

        #region Fields
        private ILevel level = null;

        #endregion
    }
}
