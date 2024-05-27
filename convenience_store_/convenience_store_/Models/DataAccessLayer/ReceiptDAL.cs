using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.EntityLayer;
using convenience_store_.ViewModels;
namespace convenience_store_.Models.DataAccessLayer
{
    static public class ReceiptDAL
    {
        static public ObservableCollection<Receipt> GetAllReceipts()
        {
            using(SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllReceipts", connection);
                ObservableCollection<Receipt> result = new ObservableCollection<Receipt>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Receipt r = new Receipt();
                    r.ID = reader.GetInt32(0);
                    r.PaymentDate = reader.GetDateTime(1);
                    r.CashierID = reader.GetInt32(2);
                    r.CashierUsername = UserDAL.GetUsernameWithId(r.CashierID);
                    r.Sublists = ProductListDAL.GetListsFromReceipt(r.ID);
                    r.Total = reader.IsDBNull(3) ? 0.0f : (float)reader.GetDouble(3);
                    r.IsActive = reader.GetBoolean(4);
                    r.Finalized = reader.GetBoolean(5);
                    result.Add(r);
                }
                reader.Close();
                return result;
            }
        }

        static public void CreateReceipt(Receipt receipt, int id)
        {
            try
            {
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("CreateReceipt", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@PaymentDate", receipt.PaymentDate);
                    command.Parameters.AddWithValue("@CashierID", receipt.CashierID);
                    command.Parameters.AddWithValue("@Total", receipt.Total);
                    command.Parameters.AddWithValue("@IsActive", true);
                    command.Parameters.AddWithValue("@Finalized", false);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public void ModifyReceipt(Receipt receipt)
        {
            try
            {
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyReceipt", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", receipt.ID);
                    command.Parameters.AddWithValue("@PaymentDate", receipt.PaymentDate);
                    command.Parameters.AddWithValue("@CashierID", receipt.CashierID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        static public void DeleteReceipt(Receipt receipt)
        {
            try
            { 
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteReceipt", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", receipt.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                StoreException.Error(e.Message);
            }
        }

        static public void FinalizeReceipt(Receipt receipt)
        {
            try
            { 
                using(SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("FinalizeReceipt", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", receipt.ID);
                    command.Parameters.AddWithValue("@Finalized", true);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                StoreException.Error(ex.Message);
            }
        }

        // add link which adds the pair int int to the Linker table in the database
    }
}
