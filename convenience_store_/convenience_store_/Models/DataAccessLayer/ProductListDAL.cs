using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace convenience_store_.Models.DataAccessLayer
{
    public class ProductListDAL
    {
        public ObservableCollection<ProductList> GetAllProductLists()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllProductLists", connection);
                ObservableCollection<ProductList> result = new ObservableCollection<ProductList>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductList p = new ProductList();
                    p.ID = reader.GetInt32(0);
                    p.ProductID = reader.GetInt32(1);
                    p.Quantity = reader.GetInt32(2);
                    p.Subtotal = reader.GetFloat(3);
                    p.IsActive = reader.GetBoolean(6);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
        }
    }
}
