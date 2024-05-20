using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string Category { get; set; }
        public int ManufacturerID { get; set; }
        public bool IsActive { get; set; }
    }
}
