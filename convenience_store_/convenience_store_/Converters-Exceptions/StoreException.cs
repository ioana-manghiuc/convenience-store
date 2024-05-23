using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Converters_Exceptions
{
    class StoreException : ApplicationException
    {
        public StoreException(string message) : base(message)
        {
            // Empty
        }
    }
}
