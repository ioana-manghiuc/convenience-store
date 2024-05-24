using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using System.Security.Policy;

namespace convenience_store_.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        static public ObservableCollection<User> UserList { get; set; }
        static public ObservableCollection<string> RolesList { get; set; }

        static public ObservableCollection<User> GetAllUsers()
        {
            return UserDAL.GetAllUsers();
        }

        static public void ModifyUser(User user)
        {
            if (user == null)
            {
                StoreException.Error("A user must be seleted");
            }
            else if (string.IsNullOrEmpty(user.Username))
            {
                StoreException.Error("Username must be specified");
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                StoreException.Error("Password must be specified");
            }
            else if (user.Role != ERole.Administrator.ToString() && user.Role != ERole.Cashier.ToString())
            {
                StoreException.Error("Incorrect data entered!\nAvailable roles: Administrator, Cashier.");
            }
            else
            {
                UserDAL.ModifyUser(user);

            }
        }

        static public void GetAllRoles(int id)
        {
            RolesList.Clear();
            var roles = UserDAL.GetAllRoles();
            foreach (var role in roles)
            {
                RolesList.Add(role);
            }
        }
    }
}
