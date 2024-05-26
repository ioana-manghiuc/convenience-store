using convenience_store_.Views.Pages;
using System;
using System.Collections.Generic;
using System.Windows;
using convenience_store_.Views.CashierPages;

namespace convenience_store_.Views
{
    /// <summary>
    /// Interaction logic for CashierView.xaml
    /// </summary>
    public partial class CashierView : Window
    {
        public CashierView()
        {
            InitializeComponent();
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CSearch());
        }

        private void CreateSublistsBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateSublists());
        }

        private void SeeReceiptsBtn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SeeReceipts());
        }
    }
}
