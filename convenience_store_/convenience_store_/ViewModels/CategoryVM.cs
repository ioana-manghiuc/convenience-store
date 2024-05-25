using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class CategoryVM : BasePropertyChanged
    {
        public CategoryVM()
        {
            CategoryList = CategoryBLL.GetAllCategories();         
            StringCategories = new ObservableCollection<string>();
            foreach (Category c in CategoryList)
            {
                StringCategories.Add(c.CategName);
            }
        }

        public ObservableCollection<Category> CategoryList
        {
            get => CategoryBLL.CategoryList;
            set => CategoryBLL.CategoryList = value;
        }
        public ObservableCollection<string> StringCategories { get; set; }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Category>(CategoryBLL.AddCategory);
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
                    modifyCommand = new RelayCommand<Category>(CategoryBLL.ModifyCategory);
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
                    deleteCommand = new RelayCommand<Category>(CategoryBLL.DeleteCategory);
                }
                return deleteCommand;
            }
        }
    }
}
