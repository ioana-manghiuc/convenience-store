using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Windows;
using convenience_store_.Models;
using convenience_store_.Models.DataAccessLayer;
using convenience_store_.Views;
using convenience_store_.Converters_Exceptions;

namespace convenience_store_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();

            // Print all users
            UserDAL userDAL = new UserDAL();
            ObservableCollection<User> users = userDAL.GetAllUsers();
            foreach (User u in users)
            {
                Console.WriteLine(u.Username);
            }

            // Print all manufacturers
            ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
            ObservableCollection<Manufacturer> manufacturers = manufacturerDAL.GetAllManufacturers();
            foreach (Manufacturer m in manufacturers)
            {
                Console.WriteLine(m.Name);
            }

        }

        private void Login(object sender, RoutedEventArgs e)
        {
            ERole role = UserDAL.GetRoleOfUser(UsernameBox.Text, PasswordBox.Password);
            if(role == ERole.Admin)
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

