﻿using System;
using System.Globalization;
using System.Windows.Data;
using convenience_store_.Models;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Converters_Exceptions
{
    public class ManufacturerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2 && values[0] != null && values[1] != null)
            {
                return new Manufacturer()
                {
                    Name = values[0].ToString(),
                    CountryOfOrigin = values[1].ToString(),
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