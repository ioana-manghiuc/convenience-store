using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models
{
    public class Receipt: BasePropertyChanged
    {
        // ID, PaymentDate, CashierID, SublistID, Total, IsActive

        private int? id;
        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private System.DateTime? paymentDate;
        public System.DateTime? PaymentDate
        {
            get { return paymentDate; }
            set
            {
                paymentDate = value;
                NotifyPropertyChanged("PaymentDate");
            }
        }

        private int? cashierId;
        public int? CashierID
        {
            get { return cashierId; }
            set
            {
                cashierId = value;
                NotifyPropertyChanged("CashierID");
            }
        }

        private int? sublistId;
        public int? SublistID
        {
            get { return sublistId; }
            set
            {
                sublistId = value;
                NotifyPropertyChanged("SublistID");
            }
        }

        private float? total;
        public float? Total
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }

        private bool? isActive;
        public bool? IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }
    }
}
