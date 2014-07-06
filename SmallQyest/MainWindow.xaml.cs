using System.Windows;
using SmallQyest.ViewModels;
using Logging;

namespace SmallQyest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAppControllerFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates App Controller.
        /// </summary>
        /// <returns>App Controller Instance.</returns>
        public IAppController GetAppController()
        {
            return new AppController();
        }

        /// <summary>
        /// Handles loading the Window.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppController controller = (AppController)this.GetAppController();
            ILogger logger = new LoggerFactory().GetLogger();
            IViewModelFactory factory = new ViewModelFactory(controller, logger);
            controller.ViewModelFactory = factory;
            controller.LevelFactory = new MockLevelFactory();
            controller.Logger = logger;

            this.DataContext = controller;
            controller.ToMainMenu();
        }

    }
}
