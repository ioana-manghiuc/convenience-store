using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.DataAccessLayer
{
    public class ProductDAL
    {
        public ObservableCollection<Product> GetAllProducts()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllProducts", connection);
                ObservableCollection<Product> result = new ObservableCollection<Product>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Barcode = reader.GetString(2);
                    p.ExpirationDate = reader.GetDateTime(3);
                    p.CategoryID = reader.GetInt32(4);
                    p.ManufacturerID = reader.GetInt32(5);
                    p.IsActive = reader.GetBoolean(6);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
        }
    }
}
