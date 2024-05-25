using System;
using System.Globalization;
using System.Windows.Data;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Converters_Exceptions
{
    public class CategoryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 1 && values[0] != null)
            {
                return new Category()
                {
                    CategName = values[0].ToString(),
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
