using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models
{
    public enum ERole
    {
        Administrator,
        Cashier,
        None
    }
    public class User : BasePropertyChanged
    {
        // ID, Username, Password, Role, IsActive

        private int? id;
        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string role;
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }

        public ERole RoleEnum
        {
            get
            {
                if (Enum.TryParse(role, out ERole parsedRole))
                {
                    return parsedRole;
                }
                return ERole.None;
            }
            set
            {
                role = value.ToString();
                NotifyPropertyChanged("Role");
            }
        }

        private bool? isActive;
        public bool? IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }
    }
}
