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
            if (values != null && values.Length == 3 && values[0] != null && values[1] != null && values[2] != null)
            {
                return new User()
                {
                    Username = values[0].ToString(),
                    Password = values[1].ToString(),
                    Role = values[2].ToString(),
                    IsActive = true
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
