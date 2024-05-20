using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    internal class Stock
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public System.DateTime SupplyDate { get; set; }
        public float BasePrice { get; set; }
        public float SellingPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
