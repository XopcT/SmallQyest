using System.Windows;
using SmallQyest.ViewModels;

namespace SmallQyest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles loading the Window.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UnityFactory factory = new UnityFactory();
            IAppController controller = factory.GetAppController();

            this.DataContext = controller;
            controller.ToMainMenu();
        }

    }
}
