using System;
using System.Globalization;
using System.Windows.Data;
using convenience_store_.Models;

namespace convenience_store_.Converters_Exceptions
{
    public class StockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values != null && values.Length == 5 && values[0] != null && values[1] != null &&
                values[2] != null && values[3] != null && values[4] != null)
            {
                DateTime? supplyDate = null;
                if (DateTime.TryParse(values[3]?.ToString(), out DateTime parsedDate))
                {
                    supplyDate = parsedDate;
                }

                return new Stock()
                {
                    ProductName = values[0].ToString(),
                    Quantity = ConvertToInt(values[1]),
                    UnitOfMeasurement = values[2].ToString(),
                    SupplyDate = supplyDate,
                    BasePrice = ConvertToFloat(values[4]),
                    IsActive = true
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

        private float ConvertToFloat(object value)
        {
            if (value is float)
            {
                return (float)value;
            }
            if (float.TryParse(value?.ToString(), out float result))
            {
                return result;
            }
            throw new InvalidCastException($"Cannot convert {value} to float.");
        }
    }
}
