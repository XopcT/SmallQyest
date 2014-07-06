using Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SmallQyest.ViewModels;

namespace SmallQyest
{
    /// <summary>
    /// Factory which creates Instances via Unity.
    /// </summary>
    public class UnityFactory : IAppControllerFactory, IViewModelFactory, ILoggerFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public UnityFactory()
        {
            this.unityContainer = new UnityContainer().LoadConfiguration("default");
            this.unityContainer.RegisterInstance<IAppControllerFactory>(this);
            this.unityContainer.RegisterInstance<IViewModelFactory>(this);
            this.unityContainer.RegisterInstance<ILoggerFactory>(this);
        }

        /// <summary>
        /// Retrieves the App Controller.
        /// </summary>
        /// <returns>App Controller Instance.</returns>
        public IAppController GetAppController()
        {
            return this.unityContainer.Resolve<IAppController>();
        }

        /// <summary>
        /// Retrieves View Model for Application main Menu.
        /// </summary>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetMainMenuViewModel()
        {
            return this.unityContainer.Resolve<IViewModel>("mainMenu");
        }

        /// <summary>
        /// Retrieves View Model for a Game Level.
        /// </summary>
        /// <param name="level">Level to create View Model for.</param>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetLevelViewModel(Core.Level level)
        {
            LevelViewModel viewModel = (LevelViewModel)this.unityContainer.Resolve<IViewModel>("level");
            viewModel.Level = level;
            return viewModel;
        }

        /// <summary>
        /// Retrieves a Logger.
        /// </summary>
        /// <returns>Logger Instance.</returns>
        public ILogger GetLogger()
        {
            return this.unityContainer.Resolve<ILogger>();
        }

        #region Properties

        #endregion

        #region Fields
        private readonly IUnityContainer unityContainer = null;

        #endregion

    }
}
