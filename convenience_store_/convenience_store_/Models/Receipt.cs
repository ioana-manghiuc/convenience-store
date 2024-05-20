using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    public class Receipt
    {
        public int ID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public int CashierID { get; set; }
        public int SublistID { get; set; }
        public float Total { get; set; }
        public bool IsActive { get; set; }
    }
}
