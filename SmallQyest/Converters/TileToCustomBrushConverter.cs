using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using SmallQyest.World;

namespace SmallQyest.Converters
{
    /// <summary>
    /// Retrieves a Brush depending on Tile's Type.
    /// </summary>
    public class TileToCustomBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts Tile Type into a Brush.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Brush to paint the Tile.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Path)
                return this.PathBrush;
            else if (value is Grass)
                return this.GrassBrush;
            return Brushes.Transparent;
        }

        /// <summary>
        /// Converts Value back.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Converted Value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Brush for a Grass Tile.
        /// </summary>
        public Brush GrassBrush { get; set; }

        /// <summary>
        /// Sets/retrieves a Brush for a Path Tile.
        /// </summary>
        public Brush PathBrush { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
