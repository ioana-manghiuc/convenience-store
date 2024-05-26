using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class StockBLL
    {
        static public ObservableCollection<Stock> StockList { get; set; }
        static public ObservableCollection<string> Products { get; set; }

        static public void AddStock(Stock stock)
        {
            if (stock == null)
            {
                StoreException.Error("Stock cannot be null.");
            }
            else if (string.IsNullOrEmpty(stock.ProductName))
            {
                StoreException.Error("A product must be selected");
            }
            else if (stock.Quantity == 0)
            {
                StoreException.Error("Quantity must be specified");
            }
            else if(string.IsNullOrEmpty(stock.UnitOfMeasurement))
            {
                StoreException.Error("Unit of measurement must be specified");
            }
            else if(stock.BasePrice == 0)
            {
                StoreException.Error("Base price must be specified");
            }
            else
            {
                stock.ProductID = ProductDAL.GetProductIdWithName(stock.ProductName);
                StockDAL.AddStock(stock, StockList.Count + 1);
                StockList.Add(stock);
            }
        }

        static public void ModifyStock(Stock stock)
        {
            if (stock == null)
            {
                StoreException.Error("A product must be selected");
            }
            else if (string.IsNullOrEmpty(stock.ProductName))
            {
                StoreException.Error("A product must be selected");
            }
            else
            {
                stock.ProductID = ProductDAL.GetProductIdWithName(stock.ProductName);
                StockDAL.ModifyStock(stock);
            }
        }

        static public ObservableCollection<Stock> GetAllStockItems()
        {
            return StockDAL.GetStockInfo();
        }
    }
}
