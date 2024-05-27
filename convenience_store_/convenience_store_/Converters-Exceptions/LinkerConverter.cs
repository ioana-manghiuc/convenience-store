using convenience_store_.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace convenience_store_.Converters_Exceptions
{
    internal class LinkerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] != null
                && values[1] != null)
            {
                int first = ConvertToInt(values[0]);
                int second = ConvertToInt(values[1]);

                return new Pair<int,int>()
                {
                    First = first,
                    Second = second
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static public int ConvertToInt(object value)
        {
            if (value is int)
            {
                return (int)value;
            }
            if (int.TryParse(value?.ToString(), out int result))
            {
                return result;
            }
            throw new InvalidCastException($"Cannot convert {value} to int.");
        }
    }
}
