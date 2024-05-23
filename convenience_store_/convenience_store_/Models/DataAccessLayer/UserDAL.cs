using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace convenience_store_.Models.DataAccessLayer
{
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
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
    }
}
