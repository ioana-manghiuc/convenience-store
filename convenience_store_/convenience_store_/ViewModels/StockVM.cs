using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.DataAccessLayer;
using convenience_store_.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class StockVM : BasePropertyChanged
    {
        public StockVM()
        {
            StockList = StockBLL.GetAllStockItems();
            ProductNames = new ObservableCollection<string>();
            foreach (Product product in ProductDAL.GetAllProducts())
            {
                ProductNames.Add(product.Name);
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Stock>(StockBLL.AddStock);
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
                    modifyCommand = new RelayCommand<Stock>(StockBLL.ModifyStock);
                }
                return modifyCommand;
            }
        }

        public ObservableCollection<Stock> StockList
        {
            get => StockBLL.StockList;
            set => StockBLL.StockList = value;
        }
        public ObservableCollection<string> ProductNames { get; set; }
    }
}
