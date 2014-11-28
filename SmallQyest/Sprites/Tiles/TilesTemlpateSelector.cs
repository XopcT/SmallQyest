using System.Windows;
using System.Windows.Controls;
using SmallQyest.World.Tiles;

namespace SmallQyest.Sprites.Tiles
{
    /// <summary>
    /// Selects an appropriate Template for a Tile.
    /// </summary>
    public class TilesTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Selects Template for the specified Tile.
        /// </summary>
        /// <param name="item">Item to select Template for.</param>
        /// <param name="container">Data-bound Object.</param>
        /// <returns>Template for the specified Tile.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Tile tile = item as Tile;
            if (tile != null)
            {
                if (tile is Grass)
                    return this.GrassTemplate;
                if (tile is Path)
                    return this.PathTemplate;
            }
            return base.SelectTemplate(item, container);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Template for a Grass Tile.
        /// </summary>
        public DataTemplate GrassTemplate { get; set; }

        /// <summary>
        /// Sets/retrieves a Template for a Path Tile.
        /// </summary>
        public DataTemplate PathTemplate { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
