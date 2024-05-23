using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.DataAccessLayer
{
    public class StockDAL
    {
        public ObservableCollection<Stock> GetStockInfo()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllStockInfo", connection);
                ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Stock s = new Stock();
                    s.ID = reader.GetInt32(0);
                    s.ProductID = reader.GetInt32(1);
                    s.Quantity = reader.GetInt32(2);
                    s.UnitOfMeasurement = reader.GetString(3);
                    s.SupplyDate = reader.GetDateTime(4);
                    s.BasePrice = reader.GetFloat(5);
                    s.SellingPrice = reader.GetFloat(6);
                    s.IsActive = reader.GetBoolean(7);
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
        }
    }
}
