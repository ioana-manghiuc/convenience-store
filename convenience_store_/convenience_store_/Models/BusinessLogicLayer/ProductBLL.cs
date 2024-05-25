using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class ProductBLL
    {
        static public ObservableCollection<Product> Products { get; set; }
        static public ObservableCollection<string> CategoryList { get; set; }
        static public ObservableCollection<string> ManufacturerList { get; set; }

        static public void AddProduct(Product product)
        {
            if(string.IsNullOrEmpty(product.Name))
            {
                StoreException.Error("Product name must be specified");
            }
            else if(string.IsNullOrEmpty(product.Barcode))
            {
                StoreException.Error("Barcode must be specified");
            }
            else if(string.IsNullOrEmpty(product.CategoryName))
            {
                StoreException.Error("Category must be specified");
            }
            else if(string.IsNullOrEmpty(product.ManufacturerName))
            {
                StoreException.Error("Manufacturer must be specified");
            }
            else
            {
                product.CategoryID = CategoryDAL.GetCategoryIdWithName(product.CategoryName);
                product.ManufacturerID = ManufacturerDAL.GetManufacturerIdWithName(product.ManufacturerName);
                ProductDAL.AddProduct(product, Products.Count + 1);
                Products.Add(product);
            }
        }

        static public void ModifyProduct(Product product)
        {
            if (product == null)
            {
                StoreException.Error("A product must be selected");
            }
            else if (string.IsNullOrEmpty(product.Name))
            {
                StoreException.Error("Product name must be specified");
            }
            else if (string.IsNullOrEmpty(product.Barcode))
            {
                StoreException.Error("Barcode must be specified");
            }
            else if (product.CategoryID == 0)
            {
                StoreException.Error("Category must be specified");
            }
            else if (product.ManufacturerID == 0)
            {
                StoreException.Error("Manufacturer must be specified");
            }
            else
            {
                product.CategoryID = CategoryDAL.GetCategoryIdWithName(product.CategoryName);
                product.ManufacturerID = ManufacturerDAL.GetManufacturerIdWithName(product.ManufacturerName);
                ProductDAL.ModifyProduct(product);
            }
        }

        static public void DeleteProduct(Product product)
        {
            if (product == null || product.ID == null)
            {
                StoreException.Error("A product must be selected");
            }
            else
            {
                ProductDAL.DeleteProduct(product);
                Products.Remove(product);
            }
        }

        static public ObservableCollection<Product> GetAllProducts()
        {
            return ProductDAL.GetAllProducts();
        }

        static public string GetCategoryName(int id)
        {
            return CategoryDAL.GetCategoryWithId(id);
        }

        static public string GetManufacturerName(int id)
        {
            return ManufacturerDAL.GetManufacturerWithId(id);
        }
    }
}
