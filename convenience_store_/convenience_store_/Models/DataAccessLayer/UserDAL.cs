using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

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

        static public void ModifyUser(User user)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUserID = new SqlParameter("@ID", user.ID);
                SqlParameter paramUserName = new SqlParameter("@Username", user.Username);
                SqlParameter paramUserPass = new SqlParameter("@Password", user.Password);
                SqlParameter paramUserRole = new SqlParameter("@Role", user.Role);              
                cmd.Parameters.Add(paramUserID);
                cmd.Parameters.Add(paramUserName);
                cmd.Parameters.Add(paramUserPass);
                cmd.Parameters.Add(paramUserRole);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public ObservableCollection<string> GetAllRoles()
        {
            ObservableCollection<string> result = new ObservableCollection<string>(Enum.GetNames(typeof(ERole)));
            return result;
        }
    }
}
