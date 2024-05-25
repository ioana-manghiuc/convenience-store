using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using convenience_store_.Models.EntityLayer;
using System.Net;
using System.Linq;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class CategoryBLL
    {
        static public ObservableCollection<Category> CategoryList { get; set; }
        static public ObservableCollection<string> StringCategories { get; set; }

        static public ObservableCollection<Category> GetAllCategories()
        {
            return CategoryDAL.GetAllCategories();
        }

        static public void AddCategory(Category category)
        {
            if(string.IsNullOrEmpty(category.CategName))
            {
                StoreException.Error("Category name must be specified");
            }
            else
            {
                CategoryDAL.AddCategory(category, CategoryList.Count + 1);
                CategoryList.Add(category);
            }
        }

        static public void ModifyCategory(Category category)
        {
            if (category == null)
            {
                StoreException.Error("A category must be selected");
            }
            else if (string.IsNullOrEmpty(category.CategName))
            {
                StoreException.Error("Category name must be specified");
            }
            else
            {
                CategoryDAL.ModifyCategory(category);
            }
        }

        static public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                StoreException.Error("A category must be selected");
            }
            else
            {
                CategoryDAL.DeleteCategory(category);
            }
        }
    }
}
