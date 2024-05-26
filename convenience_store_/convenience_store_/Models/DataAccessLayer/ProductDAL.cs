using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class ProductDAL
    {
        static public ObservableCollection<Product> GetAllProducts()
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
                    if (!reader.IsDBNull(3))
                    {
                        p.ExpirationDate = reader.GetDateTime(3);
                    }
                    else
                    {
                        p.ExpirationDate = null;
                    }
                    p.CategoryID = reader.GetInt32(4);
                    p.CategoryName = CategoryDAL.GetCategoryWithId(p.CategoryID);
                    p.ManufacturerID = reader.GetInt32(5);
                    p.ManufacturerName = ManufacturerDAL.GetManufacturerWithId(p.ManufacturerID);
                    p.IsActive = reader.GetBoolean(6);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
        }

        static public void AddProduct(Product product, int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("AddProduct", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Barcode", product.Barcode);
                    if (product.ExpirationDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ExpirationDate", System.DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@ManufacturerID", product.ManufacturerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public void ModifyProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyProduct", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", product.ID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Barcode", product.Barcode);
                    if (product.ExpirationDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ExpirationDate", System.DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@ManufacturerID", product.ManufacturerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public void DeleteProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteProduct", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", product.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public string GetProductWithId(int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetProductNameWithId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }

                    reader.Close();
                    return null;
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
                return null;
            }
        }

        static public int GetProductIdWithName(string name)
        {
            try
            {
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetProductIdWithName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }

                    reader.Close();
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
                return -1;
            }
        }

    }
}
