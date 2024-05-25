using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class CategoryDAL
    {
        static public ObservableCollection<Category> GetAllCategories()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllCategories", connection);
                ObservableCollection<Category> result = new ObservableCollection<Category>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.ID = reader.GetInt32(0);
                    c.CategName = reader.GetString(1);
                    c.IsActive = reader.GetBoolean(2);
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
        }

        static public void AddCategory(Category category, int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCategID = new SqlParameter("@ID", id);
                SqlParameter paramCategName = new SqlParameter("@CategName", category.CategName);
                SqlParameter paramCategStatus = new SqlParameter("@IsActive", true);
                command.Parameters.Add(paramCategID);
                command.Parameters.Add(paramCategName);
                command.Parameters.Add(paramCategStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void ModifyCategory(Category category)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyCategory", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramCategID = new SqlParameter("@ID", category.ID);
                    SqlParameter paramCategName = new SqlParameter("@NewCategName", category.CategName);
                    command.Parameters.Add(paramCategID);
                    command.Parameters.Add(paramCategName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
            }

        }

        static public void DeleteCategory(Category category)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteCategory", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", category.ID));
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public string GetCategoryWithId(int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetCategoryNameWithId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("CategoryName")))
                        {
                            return reader.GetString(reader.GetOrdinal("CategoryName"));
                        }
                        else if (!reader.IsDBNull(reader.GetOrdinal("ErrorMessage")))
                        {
                            string errorMessage = reader.GetString(reader.GetOrdinal("ErrorMessage"));
                            StoreException.Error(errorMessage);
                        }
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

        static public int GetCategoryIdWithName(string name)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetCategoryIdWithName", connection);
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
