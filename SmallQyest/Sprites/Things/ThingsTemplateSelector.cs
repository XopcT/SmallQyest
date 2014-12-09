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
            if (item is Bonus)
                return this.BonusTemplate;
            if (item is ColoredDoor)
                return this.ColoredDoorTemplate;
            if (item is ColoredKey)
                return this.ColoredKeyTemplate;
            if (item is ColoredLever)
                return this.ColoredLeverTemplate;
            if (item is FallTrap)
                return this.FallTrapTemplate;
            if (item is MoveableObstacle)
                return this.MoveableObstacleTemplate;
            if (item is OneTimePassObstacle)
                return this.OneTimePassObstacleTemplate;

            return base.SelectTemplate(item, container);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Template for a Bonus.
        /// </summary>
        public DataTemplate BonusTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a colored Door.
        /// </summary>
        public DataTemplate ColoredDoorTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a colored Key.
        /// </summary>
        public DataTemplate ColoredKeyTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a colored Lever.
        /// </summary>
        public DataTemplate ColoredLeverTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a Fall Trap.
        /// </summary>
        public DataTemplate FallTrapTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a moveable Obstacle.
        /// </summary>
        public DataTemplate MoveableObstacleTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a one Time pass Obstacle.
        /// </summary>
        public DataTemplate OneTimePassObstacleTemplate { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
