using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class StockDAL
    {
        static public ObservableCollection<Stock> GetStockInfo()
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
                    s.BasePrice = reader.IsDBNull(5) ? 0.0f : (float)reader.GetDouble(5);
                    s.SellingPrice = reader.IsDBNull(6) ? 0.0f : (float)reader.GetDouble(6);
                    s.IsActive = reader.GetBoolean(7);
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
        }

        static public float GetSellingPriceOfProduct(int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetSellingPriceOfProduct", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        float sellingPrice = reader.IsDBNull(0) ? 0.0f : (float)reader.GetDouble(0);
                        reader.Close();
                        return sellingPrice;
                    }
                    else
                    {
                        reader.Close();
                        return 0;
                    }
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
                return 0;
            }
        }

    }
}
