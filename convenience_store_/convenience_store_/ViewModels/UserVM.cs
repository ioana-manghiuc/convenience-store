﻿using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class UserVM : BasePropertyChanged
    {
        public UserVM() 
        {
            UsersList = UserBLL.GetAllUsers();
            RolesList = new ObservableCollection<string>(Enum.GetNames(typeof(ERole)));
            RolesList.Remove(ERole.None.ToString());
        }

        public ObservableCollection<User> UsersList
        { 
            get => UserBLL.UserList;
            set => UserBLL.UserList = value;
        }

        public ObservableCollection<string> RolesList { get; set; }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<User>(UserBLL.AddUser);
                }
                return addCommand;
            }
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

    }
}
