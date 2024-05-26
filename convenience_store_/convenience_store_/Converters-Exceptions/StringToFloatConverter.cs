using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace convenience_store_.Converters_Exceptions
{
    public class StringToFloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string str && float.TryParse(str, out float result))
            {
                return result;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is float floatValue)
            {
                return floatValue.ToString();
            }
            return "0";
        }
    }
}
