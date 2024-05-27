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
            FinalizedReceipts = new ObservableCollection<Receipt>();
            ModifiableReceipts = new ObservableCollection<Receipt>();
            ObjSublists = new ObservableCollection<ProductList>();

            foreach(User user in UserDAL.GetAllUsers())
            {
                if (!Cashiers.Contains(user.Username) && user.Role == "Cashier")
                    Cashiers.Add(user.Username);
            }

            foreach(Receipt r in ReceiptDAL.GetAllReceipts())
            {
                foreach(ProductList list in r.Sublists)
                {
                    string row = $"{list.Quantity}x {list.ProductName,-17} {list.Subtotal,10:N2} RON";
                    Sublists.Add(row);
                }
            }

            foreach(Receipt r in Receipts)
            {
                if(r.Finalized)
                {
                    FinalizedReceipts.Add(r);
                }
                else
                {
                    ModifiableReceipts.Add(r);
                }
            }

            foreach(ProductList list in ProductListDAL.GetAllProductLists())
            {
                ObjSublists.Add(list);
            }

        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Receipt>(ReceiptBLL.CreateReceipt);
                }
                return addCommand;
            }
        }

        private ICommand modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (modifyCommand == null)
                {
                    modifyCommand = new RelayCommand<Receipt>(ReceiptBLL.ModifyReceipt);
                }
                return modifyCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Receipt>(ReceiptBLL.DeleteReceipt);
                }
                return deleteCommand;
            }
        }

        private ICommand finalizeCommand;
        public ICommand FinalizeCommand
        {
            get
            {
                if (finalizeCommand == null)
                {
                    finalizeCommand = new RelayCommand<Receipt>(ReceiptBLL.FinalizeReceipt);
                }
                return finalizeCommand;
            }
        }

        public ObservableCollection<Receipt> Receipts
        {
            get => ReceiptBLL.Receipts;
            set => ReceiptBLL.Receipts = value;
        }
        public ObservableCollection<string> Cashiers { get; set; }  

        public ObservableCollection<string> Sublists { get; set; }
        public ObservableCollection<ProductList> ObjSublists { get; set; }
        public ObservableCollection<Receipt> FinalizedReceipts { get; set;}
        public ObservableCollection<Receipt> ModifiableReceipts { get; set;}


    }
}
