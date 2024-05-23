using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.DataAccessLayer
{
    public class ReceiptDAL
    {
        public ObservableCollection<Receipt> GetAllReceipts()
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
                    r.SublistID = reader.GetInt32(3);
                    r.Total = reader.GetFloat(4);
                    r.IsActive = reader.GetBoolean(5);
                    result.Add(r);
                }
                reader.Close();
                return result;
            }
        }
    }
}
