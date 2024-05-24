using System;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Windows;
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

            // Print all installed fonts
            PrintInstalledFonts();
        }

        private void PrintInstalledFonts()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            // Get the array of FontFamily objects.
            System.Drawing.FontFamily[] fontFamilies = installedFontCollection.Families;

            // Print the name of each font family to the console.
            foreach (System.Drawing.FontFamily fontFamily in fontFamilies)
            {
                Console.WriteLine(fontFamily.Name);
            }
        }
    }
}

