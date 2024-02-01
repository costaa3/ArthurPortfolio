using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMCurrencyConverter.Converter
{
    internal class StringToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal d;
            return decimal.TryParse(value.ToString(), out d) ? d : 0m;

        }
    }
}
