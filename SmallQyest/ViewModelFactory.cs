using SmallQyest.ViewModels;
using SmallQyest.Core;
using Logging;

namespace SmallQyest
{
    /// <summary>
    /// Factory which creates View Models.
    /// </summary>
    public class ViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="appController">Application Controller Instance.</param>
        /// <param name="logger">Logger for Application Messages.</param>
        public ViewModelFactory(IAppController appController, ILogger logger)
        {
            this.appController = appController;
            this.logger = logger;
        }

        /// <summary>
        /// Retrieves View Model for Application main Menu.
        /// </summary>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetMainMenuViewModel()
        {
            MenuViewModel viewModel = new MenuViewModel();
            viewModel.AppController = this.appController;
            viewModel.Logger = this.logger;
            return viewModel;
        }

        /// <summary>
        /// Retrieves View Model for a Game Level.
        /// </summary>
        /// <param name="level">Level to create View Model for.</param>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetLevelViewModel(Level level)
        {
            LevelViewModel viewModel = new LevelViewModel();
            viewModel.AppController = this.appController;
            viewModel.Level = level;
            viewModel.Logger = logger;
            return viewModel;
        }

        #region Properties

        #endregion

        #region Fields

        private readonly IAppController appController = null;
        private readonly ILogger logger = null;

        #endregion
    }
}
