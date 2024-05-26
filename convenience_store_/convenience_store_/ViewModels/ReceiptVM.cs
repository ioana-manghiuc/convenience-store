using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.DataAccessLayer;
using convenience_store_.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace convenience_store_.ViewModels
{
    public class ReceiptVM : BasePropertyChanged
    {
        public ReceiptVM()
        {
            Receipts = ReceiptBLL.GetAllReceipts();
            Cashiers = new ObservableCollection<string>();
            Sublists = new ObservableCollection<string>();

            foreach (Receipt r in ReceiptDAL.GetAllReceipts())
            {
                Cashiers.Add(r.CashierUsername);
            }

            foreach(Receipt r in ReceiptDAL.GetAllReceipts())
            {
                foreach(ProductList list in r.Sublists)
                {
                    string row = $"{list.Quantity}x {list.ProductName,-17} {list.Subtotal,10:N2} RON";
                    Sublists.Add(row);
                }
            }

        }

        public ObservableCollection<Receipt> Receipts
        {
            get => ReceiptBLL.Receipts;
            set => ReceiptBLL.Receipts = value;
        }
        public ObservableCollection<string> Cashiers { get; set; }  

        public ObservableCollection<string> Sublists { get; set; }
    }
}
