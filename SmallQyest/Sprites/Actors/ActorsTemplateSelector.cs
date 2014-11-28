using System.Windows;
using System.Windows.Controls;
using SmallQyest.World.Characters;

namespace SmallQyest.Sprites.Actors
{
    /// <summary>
    /// Selects an appropriate Template for an Actor.
    /// </summary>
    public class ActorsTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Selects Template for the specified Actor.
        /// </summary>
        /// <param name="item">Item to select Template for.</param>
        /// <param name="container">Data-bound Object.</param>
        /// <returns>Template for the specified Actor.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CharacterBase actor = item as CharacterBase;
            if (actor != null)
            {
                if (actor is Player)
                    return this.PlayerTemplate;
            }
            return base.SelectTemplate(item, container);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Template for a Player.
        /// </summary>
        public DataTemplate PlayerTemplate { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
