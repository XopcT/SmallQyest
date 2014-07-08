using SmallQyest.Models;
using SmallQyest.World.Things;
using System.Windows;
using System.Windows.Controls;

namespace SmallQyest.Sprites
{
    /// <summary>
    /// Selects an appropriate Template for a Thing.
    /// </summary>
    public class ThingsTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Selects Template for the specified Thing.
        /// </summary>
        /// <param name="item">Item to select Template for.</param>
        /// <param name="container">Data-bound Object.</param>
        /// <returns>Template for the specified Thing.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            WrapperBase<Thing> thing = item as WrapperBase<Thing>;
            if (thing != null)
            {
                if (thing.Wrapped is FallTrap)
                    return this.FallTrapTemplate;
                if (thing.Wrapped is OneTimePassObstacle)
                    return this.OneTimePassObstacleTemplate;
                if (thing.Wrapped is MoveableObstacle)
                    return this.MoveableObstacleTemplate;
            }
            return base.SelectTemplate(item, container);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Template for a Fall Trap.
        /// </summary>
        public DataTemplate FallTrapTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a one Time pass Obstacle.
        /// </summary>
        public DataTemplate OneTimePassObstacleTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a moveable Obstacle.
        /// </summary>
        public DataTemplate MoveableObstacleTemplate { get; set; }

        #endregion

        #region Fields

        #endregion


    }
}
