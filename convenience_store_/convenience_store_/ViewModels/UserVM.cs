using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class UserVM : BasePropertyChanged
    {
        public UserVM() 
        {
            UsersList = UserBLL.GetAllUsers();
        }

        public ObservableCollection<User> UsersList
        { 
            get => UserBLL.UserList;
            set => UserBLL.UserList = value;
        }

        public ObservableCollection<string> RolesList
        {
            get => UserBLL.RolesList;
            set => UserBLL.RolesList = value;
        }

        private ICommand modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (modifyCommand == null)
                {
                    modifyCommand = new RelayCommand<User>(UserBLL.ModifyUser);
                }
                return modifyCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand 
        {             
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<User>(UserBLL.DeleteUser);
                }
                return deleteCommand;
            }
        }

        private ICommand changeRolesCommand;
        public ICommand ChangeRolesCommand
        {
            get
            {
                if (changeRolesCommand == null)
                {
                    changeRolesCommand = new RelayCommand<int>(UserBLL.GetAllRoles);
                }
                return changeRolesCommand;
            }
        }

    }
}
