using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.DataAccessLayer;
using convenience_store_.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace convenience_store_.ViewModels
{
    public class ProductListVM : BasePropertyChanged
    {
        public ProductListVM()
        {
            ProductLists = ProductListBLL.GetAllSublists();
            ProductNames = new ObservableCollection<string>();
            foreach(Product product in ProductDAL.GetAllProducts())
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
                    addCommand = new RelayCommand<ProductList>(ProductListBLL.AddProductList);
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
                    modifyCommand = new RelayCommand<ProductList>(ProductListBLL.ModifyProductList);
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
                    deleteCommand = new RelayCommand<ProductList>(ProductListBLL.DeleteProductList);
                }
                return deleteCommand;
            }
        }

        public ObservableCollection<ProductList> ProductLists
        {
            get => ProductListBLL.ProductLists;
            set => ProductListBLL.ProductLists = value;
        }

        public ObservableCollection<string> ProductNames { get; set; }
    }
}
