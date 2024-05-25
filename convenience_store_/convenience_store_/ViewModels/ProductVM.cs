using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class ProductVM : BasePropertyChanged
    {
        public ProductVM()
        {
            Products = ProductBLL.GetAllProducts();
            CategoryList = new ObservableCollection<string>();
            ManufacturerList = new ObservableCollection<string>();
            foreach(Category category in CategoryBLL.GetAllCategories())
            {
                CategoryList.Add(ProductBLL.GetCategoryName(category.ID));
            }
            foreach(Manufacturer manufacturer in ManufacturerBLL.GetAllManufacturers())
            {
                ManufacturerList.Add(ProductBLL.GetManufacturerName(manufacturer.ID));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Product>(ProductBLL.AddProduct);
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
                    modifyCommand = new RelayCommand<Product>(ProductBLL.ModifyProduct);
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
                    deleteCommand = new RelayCommand<Product>(ProductBLL.DeleteProduct);
                }
                return deleteCommand;
            }
        }

        public ObservableCollection<Product> Products
        {
            get => ProductBLL.Products;
            set => ProductBLL.Products = value;
        }

        public ObservableCollection<string> CategoryList { get; set; }
        public ObservableCollection<string> ManufacturerList { get; set; }
    }
}
