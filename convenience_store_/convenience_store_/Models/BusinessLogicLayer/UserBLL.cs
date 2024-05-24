using convenience_store_.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.BusinessLogicLayer
{
    public class UserBLL
    {
        public ObservableCollection<User> UserList { get; set; }
        UserDAL userDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
    }
}
