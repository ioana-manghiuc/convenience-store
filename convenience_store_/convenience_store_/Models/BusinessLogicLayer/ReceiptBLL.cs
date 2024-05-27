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

        static public void CreateReceipt(Receipt receipt)
        {
            if(receipt == null)
            {
                StoreException.Error("Receipt cannot be null.");
            }
            else if(receipt.PaymentDate == null)
            {
                StoreException.Error("Payment date must be specified.");
            }
            else if(string.IsNullOrEmpty(receipt.CashierUsername))
            {
                StoreException.Error("Cashier must be specified.");
            }
            else
            {
                receipt.CashierID = UserDAL.GetIdOfUser(receipt.CashierUsername);
                ReceiptDAL.CreateReceipt(receipt, Receipts.Count + 1);
                Receipts.Add(receipt);
            }
        }

        static public void ModifyReceipt(Receipt receipt)
        {
            if(receipt == null)
            {
                StoreException.Error("Receipt cannot be null.");
            }
            else if(receipt.PaymentDate == null)
            {
                StoreException.Error("Payment date must be specified.");
            }
            else if(string.IsNullOrEmpty(receipt.CashierUsername))
            {
                StoreException.Error("Cashier must be specified.");
            }
            else
            {
                receipt.CashierID = UserDAL.GetIdOfUser(receipt.CashierUsername);
                ReceiptDAL.ModifyReceipt(receipt);
            }
        }   

        static public void DeleteReceipt(Receipt receipt)
        {
            if(receipt == null)
            {
                StoreException.Error("Receipt cannot be null.");
            }
            else
            {
                ReceiptDAL.DeleteReceipt(receipt);
                Receipts.Remove(receipt);
            }
        }

        static public void FinalizeReceipt(Receipt receipt)
        {
            if(receipt == null)
            {
                StoreException.Error("Receipt cannot be null.");
            }
            else
            {
                ReceiptDAL.FinalizeReceipt(receipt);
            }
        }

        static public ObservableCollection<Receipt> GetAllReceipts()
        {
            return ReceiptDAL.GetAllReceipts();
        }
    }
}
