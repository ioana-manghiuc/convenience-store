using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models
{
    public class ProductList: BasePropertyChanged
    {
        // ID, ProductID, Quantity, Subtotal, IsActive

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

        private int? productId;
        public int? ProductID
        {
            get { return productId; }
            set
            {
                productId = value;
                NotifyPropertyChanged("ProductID");
            }
        }

        private int? quantity;
        public int? Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private float? subtotal;
        public float? Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                NotifyPropertyChanged("Subtotal");
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
