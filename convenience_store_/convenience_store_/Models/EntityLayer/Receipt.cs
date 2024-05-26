using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;
using convenience_store_.ViewModels;

namespace convenience_store_.Models
{
    public class Receipt: BasePropertyChanged
    {
        // ID, PaymentDate, CashierID, SublistID, Total, IsActive

        private int id;
        public int ID
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

        private int cashierId;
        public int CashierID
        {
            get { return cashierId; }
            set
            {
                cashierId = value;
                NotifyPropertyChanged("CashierID");
            }
        }

        private string cashierUsername;
        public string CashierUsername
        {
            get { return cashierUsername; }
            set
            {
                cashierUsername = value;
                NotifyPropertyChanged("CashierUsername");
            }
        }

        private ObservableCollection<ProductList> sublists;
        public ObservableCollection<ProductList> Sublists
        {
            get { return sublists; }
            set
            {
                sublists = value;
                NotifyPropertyChanged("Sublists");
            }
        }

        private ObservableCollection<string> stsublists;
        public ObservableCollection<string> StringSublists
        {
            get
            {
                if (stsublists == null)
                {
                    stsublists = new ObservableCollection<string>();
                    foreach (var list in Sublists)
                    {
                        if (list.ProductName.Length > 13)
                        {
                            string firstPart = $"{list.Quantity}x {list.ProductName}";
                            string secondPart = $"{list.Subtotal,29:N2} RON";
                            stsublists.Add(firstPart);
                            stsublists.Add(secondPart);
                        }
                        else
                        {
                            string formattedString = $"{list.Quantity}x {list.ProductName,-15} {list.Subtotal,10:N2} RON";
                            stsublists.Add(formattedString);
                        }
                    }
                }
                return stsublists;
            }
            set
            {
                stsublists = value;
                NotifyPropertyChanged("StringSublists");
            }
        }

        private float total;
        public float Total
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }

        private bool isActive;
        public bool IsActive
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
