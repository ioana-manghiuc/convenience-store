using System;
using System.Globalization;
using System.Windows.Data;
using convenience_store_.Models;

namespace convenience_store_.Converters_Exceptions
{
    class UserConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new User()
                {
                    Username = values[0].ToString(),
                    Role = values[1].ToString()
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
