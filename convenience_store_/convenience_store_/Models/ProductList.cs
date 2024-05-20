using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    public class ProductList
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Subtotal { get; set; }
        public bool IsActive { get; set; }
    }
}
