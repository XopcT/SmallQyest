using SmallQyest.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SmallQyest.Views
{
    /// <summary>
    /// Selects an appropriate Template for an Application's Screen.
    /// </summary>
    public class ScreenTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Selects Template for the specified Screen.
        /// </summary>
        /// <param name="item">Item to select Template for.</param>
        /// <param name="container">Data-bound Object.</param>
        /// <returns>Template for the specified Screen.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MenuViewModel)
                return this.MenuTemplate;
            // TODO Select Template for a Level List.
            // TODO Select Template for a Game Level.
            return base.SelectTemplate(item, container);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves Template for Menu.
        /// </summary>
        public DataTemplate MenuTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves Template for Level List.
        /// </summary>
        public DataTemplate LevelListTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves Template for a Game Level.
        /// </summary>
        public DataTemplate GameLevelTemplate { get; set; }

        #endregion
    }
}
