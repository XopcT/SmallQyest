using System;
using System.Windows;
using System.Windows.Data;

namespace SmallQyest.Converters
{
    /// <summary>
    /// Converts inverse boolean Value into Visibility.
    /// </summary>
    public class NegativeBoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts an Input Value.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns><see cref="Visibility.Collapsed"/> if Value is True, <see cref="System.Windows.Visibility.Visible"/> otherwise.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isVisible = (bool)value;
            if (!isVisible)
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
        /// <returns>False if <see cref="Visibility.Visible"/>, True otherwise.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            if (visibility == Visibility.Visible)
                return false;
            else
                return true;
        }
    }
}
