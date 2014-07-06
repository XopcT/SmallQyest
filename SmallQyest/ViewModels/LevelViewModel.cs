using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmallQyest.Core;
using SmallQyest.World;
using System.Windows.Input;

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
        }

        /// <summary>
        /// Handles Navigation to this View Model.
        /// </summary>
        public override async void OnNavigateTo()
        {
            base.OnNavigateTo();
            await Task.Run(() => this.MainLoop(this.cancel.Token), this.cancel.Token);
        }

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        public override void OnNavigateFrom()
        {
            base.OnNavigateFrom();
            this.cancel.Cancel();
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
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
            base.Logger.LogMessage("Level Loop exited");
        }

        /// <summary>
        /// Handles going back from the Level.
        /// </summary>
        private void OnBack()
        {
            this.cancel.Cancel();
            base.AppController.ToMainMenu();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Level.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Retrieves the Ground Tiles of the Map.
        /// </summary>
        public IEnumerable<IItem> GroundTiles
        {
            get
            {
                if (this.Level != null && this.Level.Map != null)
                    return this.Level.Map.Where(item => item.GetType().IsSubclassOf(typeof(Ground)));
                return new IItem[0];
            }
        }

        /// <summary>
        /// Retrieves a Command to go Back from the Level.
        /// </summary>
        public ICommand Back { get; private set; }

        #endregion

        #region Fields

        private CancellationTokenSource cancel = new CancellationTokenSource();

        #endregion
    }
}
