using System.Windows;
using System.Windows.Controls;
using SmallQyest.World.Things;

namespace SmallQyest.Sprites.Things
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
            Thing thing = item as Thing;
            if (thing != null)
            {
                if (thing is FallTrap)
                    return this.FallTrapTemplate;
                if (thing is OneTimePassObstacle)
                    return this.OneTimePassObstacleTemplate;
                if (thing is MoveableObstacle)
                    return this.MoveableObstacleTemplate;
                if (thing is Bonus)
                    return this.BonusTemplate;
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

        /// <summary>
        /// Sets/retrieves a Template for a Bonus.
        /// </summary>
        public DataTemplate BonusTemplate { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
