using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using SmallQyest.World;

namespace SmallQyest.Converters
{
    /// <summary>
    /// Retrieves a Color depending on Tile's Type.
    /// </summary>
    public class TileTypeToColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts Tile Type into a Color.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Color to paint the Tile.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Path)
                return Brushes.Brown;
            else if (value is Grass)
                return Brushes.Green;
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
            // Back Conversion is not supported:
            throw new InvalidOperationException();
        }
    }
}
