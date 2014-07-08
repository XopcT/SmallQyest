using Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SmallQyest.Core;
using SmallQyest.ViewModels;
using SmallQyest.World;

namespace SmallQyest
{
    // TODO Make a LifetimeManager for a Level.

    /// <summary>
    /// Factory which creates Instances via Unity.
    /// </summary>
    public class UnityFactory : IAppControllerFactory, IViewModelFactory, ILoggerFactory, IItemFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public UnityFactory()
        {
            this.unityContainer = new UnityContainer()
                .LoadConfiguration("application")
                .LoadConfiguration("world");
            this.unityContainer.RegisterInstance<IAppControllerFactory>(this);
            this.unityContainer.RegisterInstance<IViewModelFactory>(this);
            this.unityContainer.RegisterInstance<ILoggerFactory>(this);
            this.unityContainer.RegisterInstance<IItemFactory>(this);
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
        public IViewModel GetLevelViewModel(ILevel level)
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

        /// <summary>
        /// Retrieves a Level.
        /// </summary>
        /// <returns>Level Instance.</returns>
        public ILevel GetLevel()
        {
            return this.unityContainer.Resolve<ILevel>();
        }

        /// <summary>
        /// Retrieves a Player Item.
        /// </summary>
        /// <returns>Player Instance.</returns>
        public IItem GetPlayer()
        {
            return this.unityContainer.Resolve<IItem>("player");
        }

        /// <summary>
        /// Retrieves a Grass Item.
        /// </summary>
        /// <returns>Grass Instance.</returns>
        public IItem GetGrass()
        {
            return this.unityContainer.Resolve<IItem>("grass");
        }

        /// <summary>
        /// Retrieves a Path Item.
        /// </summary>
        /// <returns>Path Instance.</returns>
        public IItem GetPath()
        {
            return this.unityContainer.Resolve<IItem>("path");
        }

        /// <summary>
        /// Retrieves a Level Start.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        public IItem GetLevelStartTrigger()
        {
            return this.unityContainer.Resolve<IItem>("levelStart");
        }

        /// <summary>
        /// Retrieves a Level End.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        public IItem GetLevelEndTrigger()
        {
            return this.unityContainer.Resolve<IItem>("levelEnd");
        }

        /// <summary>
        /// Retrieves a Fall Trap.
        /// </summary>
        /// <returns>Fall Trap Instance.</returns>
        public IItem GetFallTrap()
        {
            return this.unityContainer.Resolve<IItem>("fallTrap");
        }

        /// <summary>
        /// Retrieves a one Time pass Obstacle.
        /// </summary>
        /// <returns>One Time pass Obstacle Instance.</returns>
        public IItem GetOneTimePassObstacle()
        {
            return this.unityContainer.Resolve<IItem>("oneTimePassObstacle");
        }

        /// <summary>
        /// Retrieves a moveable Obstacle.
        /// </summary>
        /// <returns>Moveable Obstacle Instance.</returns>
        public IItem GetMoveableObstacle()
        {
            return this.unityContainer.Resolve<IItem>("moveableObstacle");
        }

        #region Properties

        #endregion

        #region Fields
        private readonly IUnityContainer unityContainer = null;

        #endregion
    }
}
