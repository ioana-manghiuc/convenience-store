using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public bool IsActive { get; set; }
    }
}
