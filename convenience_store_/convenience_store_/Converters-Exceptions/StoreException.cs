using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace convenience_store_.Converters_Exceptions
{
    class StoreException 
    {
        static public void Error(string message) 
        {
            MessageBox.Show(message, "Store Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
