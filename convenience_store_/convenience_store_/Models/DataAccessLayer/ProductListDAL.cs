using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class ProductListDAL
    {
        static public ObservableCollection<ProductList> GetAllProductLists()
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
                    p.ProductName = ProductDAL.GetProductWithId(p.ProductID);
                    p.Quantity = reader.GetInt32(2);
                    p.Subtotal = reader.IsDBNull(3) ? 0.0f : (float)reader.GetDouble(3);
                    p.IsActive = reader.GetBoolean(4);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
        }
        

        static public void AddProductList(ProductList productList, int id)
        {
            float price = StockDAL.GetSellingPriceOfProduct(productList.ProductID);
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("AddProductList", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@ProductID", productList.ProductID);
                    command.Parameters.AddWithValue("@Quantity", productList.Quantity);
                    if(price != 0)
                    {
                        productList.Subtotal = price * productList.Quantity;
                    }
                    else
                    {
                        productList.Subtotal = 0;
                    }
                    command.Parameters.AddWithValue("@Subtotal", productList.Subtotal);
                    command.Parameters.AddWithValue("@IsActive", true);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }


        static public void ModifyProductList(ProductList productList)
        {
            float price = StockDAL.GetSellingPriceOfProduct(productList.ProductID);
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyProductList", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", productList.ID);
                    command.Parameters.AddWithValue("@ProductID", productList.ProductID);
                    command.Parameters.AddWithValue("@Quantity", productList.Quantity);
                    if (price != 0)
                    {
                        productList.Subtotal = price * productList.Quantity;
                    }
                    else
                    {
                        productList.Subtotal = 0;
                    }
                    command.Parameters.AddWithValue("@Subtotal", productList.Subtotal);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public void DeleteProductList(ProductList productList)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteProductList", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", productList.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public ProductList GetSublistWithId(int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetSublistWithId", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ProductList p = new ProductList();
                        p.ID = reader.GetInt32(0);
                        p.ProductID = reader.GetInt32(1);
                        p.ProductName = ProductDAL.GetProductWithId(p.ProductID);
                        p.Quantity = reader.GetInt32(2);
                        p.Subtotal = reader.IsDBNull(3) ? 0.0f : (float)reader.GetDouble(3);
                        p.IsActive = reader.GetBoolean(4);
                        return p;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
                return null;
            }
        }

        static public ObservableCollection<ProductList> GetListsFromReceipt(int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetListsFromReceipt", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    ObservableCollection<ProductList> result = new ObservableCollection<ProductList>();
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductList p = new ProductList();
                        p.ID = reader.GetInt32(0);
                        p.ProductID = reader.GetInt32(1);
                        p.ProductName = ProductDAL.GetProductWithId(p.ProductID);
                        p.Quantity = reader.GetInt32(2);
                        p.Subtotal = reader.IsDBNull(3) ? 0.0f : (float)reader.GetDouble(3);
                        p.IsActive = reader.GetBoolean(4);
                        result.Add(p);
                    }
                    reader.Close();
                    return result;
                }

            }
            catch (SqlException e)
            {
                StoreException.Error(e.Message);
                return null;
            }
        }

    }
}
