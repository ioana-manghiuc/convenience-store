using convenience_store_.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace convenience_store_.Converters_Exceptions
{
    public class ReceiptConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] != null && values[1] != null)
            {
                DateTime? paymentDate = null;
                if (DateTime.TryParse(values[0]?.ToString(), out DateTime parsedDate))
                {
                    paymentDate = parsedDate;
                }

                return new Receipt()
                {
                    PaymentDate = paymentDate,
                    CashierUsername = values[1].ToString(),
                    Total = 0.0f,
                    Finalized = false,
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
