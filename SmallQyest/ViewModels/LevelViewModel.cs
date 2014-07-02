using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmallQyest.ViewModels
{
    /// <summary>
    /// View Model for a Game Level.
    /// </summary>
    public class LevelViewModel : ViewModelBase
    {
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

        private async void MainLoop(CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
        }

        #region Properties

        #endregion

        #region Fields
        private CancellationTokenSource cancel = new CancellationTokenSource();

        #endregion
    }
}
