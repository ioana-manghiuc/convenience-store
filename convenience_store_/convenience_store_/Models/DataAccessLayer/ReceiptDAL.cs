using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
