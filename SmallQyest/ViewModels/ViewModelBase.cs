using Logging;

namespace SmallQyest.ViewModels
{
    /// <summary>
    /// Base Class for creating View Models.
    /// </summary>
    public class ViewModelBase : BindableBase, IViewModel
    {
        /// <summary>
        /// Handles Navigation to this View Model.
        /// </summary>
        public virtual void OnNavigateTo()
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        public virtual void OnNavigateFrom()
        {
            // Nothing needs to be done in current Context.
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Application Controller.
        /// </summary>
        public IAppController AppController { get; set; }

        /// <summary>
        /// Sets/retrieves the Logger for Application Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
