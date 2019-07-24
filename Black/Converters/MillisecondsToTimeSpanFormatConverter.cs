using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;

using Xamarin.Forms;

using Black.Views.Controls;
using Black.Models;


namespace Black.Converters
{
    public class MillisecondsToTimeSpanFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var milliseconds = (int)value;
            var span = new TimeSpan(0, 0, 0, 0, milliseconds);

            return span.ToString(@"m\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
