// <copyright file="AgeLimitToBrushConverter.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesWPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Converter class for ageLimit to brush.
    /// </summary>
    public class AgeLimitToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts an age to a colour.
        /// </summary>
        /// <param name="value">Value, which should be converted.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object parameter.</param>
        /// <param name="culture">Culture info.</param>
        /// <returns>Returns a colour.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int age = (int)value;
            switch (age)
            {
                case int n when n >= 18: return Brushes.Red;
                case int n when n <= 6: return Brushes.LightGreen;
                default: return Brushes.Yellow;
            }
        }

        /// <summary>
        /// It does nothing.
        /// </summary>
        /// <param name="value">Value,which should be converted back.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object paramter.</param>
        /// <param name="culture">Culture info.</param>
        /// <returns>Returns nothing.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
