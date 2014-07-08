using System;
using System.Windows;
using System.Windows.Data;

namespace SmallQyest.Converters
{
    /// <summary>
    /// Converts boolean Value into Visibility.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts an Input Value.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Scaled Value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isVisible = (bool)value;
            if (isVisible)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts Value back.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Converted Value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
