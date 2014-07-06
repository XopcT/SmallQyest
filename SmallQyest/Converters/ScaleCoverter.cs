using System;
using System.Globalization;
using System.Windows.Data;

namespace SmallQyest.Converters
{
    /// <summary>
    /// Multiplies an Input integer Value by specified Factor.
    /// </summary>
    public class ScaleCoverter : IValueConverter
    {
        /// <summary>
        /// Converts an Input Value.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">The Type to convert to.</param>
        /// <param name="parameter">The Converter Parameter to use.</param>
        /// <param name="culture">The Culture to use in the Converter.</param>
        /// <returns>Scaled Value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.ScaleFactor * (int)value;
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
            throw new InvalidOperationException();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Factor to scale.
        /// </summary>
        public double ScaleFactor { get; set; }

        #endregion
    }
}
