using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;

using Xamarin.Forms;

using Black.Views.Controls;
using Black.Models;


namespace Black.Converters
{
    public class TrueToFalseConverter : IValueConverter
    {
        bool Toggle(object value)
        {
            try {
                return !System.Convert.ToBoolean(value as string);
            }
            catch (FormatException e)
            {
                return true;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Toggle(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Toggle(value);
        }
    }
}
