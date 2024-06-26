﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class UserDAL
    {
        static public ObservableCollection<User> GetAllUsers()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllUsers", connection);
                ObservableCollection<User> result = new ObservableCollection<User>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User u = new User();
                    u.ID = reader.GetInt32(0);
                    u.Username = reader.GetString(1);
                    u.Password = reader.GetString(2);
                    u.Role = reader.GetString(3);
                    u.IsActive = reader.GetBoolean(4);
                    result.Add(u);
                }
                reader.Close();
                return result;
            }
        }

        static public ERole GetRoleOfUser(string username, string password)
        {
            ERole role = ERole.None; // in case it's not found
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetRoleOfUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string roleStr = reader.GetString(0);
                    Enum.TryParse(roleStr, out role);
                }
                reader.Close();
            }
            return role;
        }

        static public void AddUser(User user, int id)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("AddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramUserID = new SqlParameter("@ID", id);
                    SqlParameter paramUserName = new SqlParameter("@Username", user.Username);
                    SqlParameter paramUserPass = new SqlParameter("@Password", user.Password);
                    SqlParameter paramUserRole = new SqlParameter("@Role", user.Role);
                    SqlParameter paramUserStatus = new SqlParameter("@IsActive", true);
                    command.Parameters.Add(paramUserID);
                    command.Parameters.Add(paramUserName);
                    command.Parameters.Add(paramUserPass);
                    command.Parameters.Add(paramUserRole);
                    command.Parameters.Add(paramUserStatus);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public void ModifyUser(User user)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramUserID = new SqlParameter("@ID", user.ID);
                    SqlParameter paramUserName = new SqlParameter("@Username", user.Username);
                    SqlParameter paramUserPass = new SqlParameter("@Password", user.Password);
                    SqlParameter paramUserRole = new SqlParameter("@Role", user.Role);
                    command.Parameters.Add(paramUserID);
                    command.Parameters.Add(paramUserName);
                    command.Parameters.Add(paramUserPass);
                    command.Parameters.Add(paramUserRole);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", user.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public string GetUsernameWithId(int id)
        {
            try
            {
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetUsernameWithId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read(); 
                            return reader.GetString(0);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
                return null;
            }
        }

        static public int GetIdOfUser(string username)
        {
            try
            {
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("GetIdOfUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) // Check if there are any rows to read
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        // Handle the case where no rows are returned
                        StoreException.Error("No user found with the specified username.");
                        return 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
                return 0;
            }
        }
    }
}
