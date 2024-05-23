using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using convenience_store_.Models;
using convenience_store_.Models.DataAccessLayer;

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
            UserDAL userDAL = new UserDAL();
            ObservableCollection<User> users = userDAL.GetAllUsers();
            foreach (User u in users)
            {
                Console.WriteLine(u.Username);
            }
            ManufacturerDAL manufacturerDAL = new ManufacturerDAL();
            ObservableCollection<Manufacturer> manufacturers = manufacturerDAL.GetAllManufacturers();
            foreach (Manufacturer m in manufacturers)
            {
                Console.WriteLine(m.Name);
            }

        }
    }
}
