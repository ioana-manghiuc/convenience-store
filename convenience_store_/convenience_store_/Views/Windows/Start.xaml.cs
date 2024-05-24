using System;
using System.Collections.ObjectModel;
using System.Windows;
using convenience_store_.Models;
using convenience_store_.Models.DataAccessLayer;
using convenience_store_.Views;
using convenience_store_.Converters_Exceptions;
using System.Windows.Controls;

namespace convenience_store_
{
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            ERole role = UserDAL.GetRoleOfUser(UsernameBox.Text, PasswordBox.Password);
            if (role == ERole.Administrator)
            {
                AdminView adminView = new AdminView();
                adminView.Show();
            }
            else if(role == ERole.Cashier)
            {
                CashierView cashierView = new CashierView();
                cashierView.Show();
            }
            else
            {
                StoreException.Error("Invalid username or password");
            }
        }
    }
}

