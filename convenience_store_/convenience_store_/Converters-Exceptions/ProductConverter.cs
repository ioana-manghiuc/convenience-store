using System;
using System.Globalization;
using System.Windows.Data;
using convenience_store_.Models;

namespace convenience_store_.Converters_Exceptions
{
    public class ProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 5 && values[0] != null && values[1] != null &&
                values[2] != null && values[3] != null && values[4] != null)
            {
                DateTime? expirationDate = null;
                if (DateTime.TryParse(values[2]?.ToString(), out DateTime parsedDate))
                {
                    expirationDate = parsedDate;
                }


                return new Product()
                {
                    Name = values[0].ToString(),
                    Barcode = values[1].ToString(),
                    ExpirationDate = expirationDate,
                    CategoryName = values[3].ToString(),
                    ManufacturerName = values[4].ToString(),
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
