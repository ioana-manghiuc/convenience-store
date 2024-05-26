using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class ReceiptBLL
    {
        static public ObservableCollection<Receipt> Receipts { get; set; }
        static public ObservableCollection<string> Cashiers { get; set; }

        static public ObservableCollection<ProductList> Sublists { get; set; }


        static public ObservableCollection<Receipt> GetAllReceipts()
        {
            return ReceiptDAL.GetAllReceipts();
        }
    }
}
