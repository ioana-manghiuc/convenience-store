using System.Windows;
using convenience_store_.Views.Pages;

namespace convenience_store_.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void CategoryBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryPage());
        }

        private void ManufacturerBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturerPage());
        }

        private void ProductBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductPage());
        }

        private void ReceiptBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReceiptPage());
        }

        private void StockBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StockPage());
        }

        private void UserBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserPage());
        }
    }
}
