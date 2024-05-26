using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System;
using System.Collections.ObjectModel;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class ProductListBLL
    {
        static public ObservableCollection<ProductList> ProductLists { get; set; }
        static public ObservableCollection<string> Products { get; set; }

        static public void AddProductList(ProductList list)
        {
            if (list == null)
            {
                StoreException.Error("List cannot be null.");
            }
            else if (string.IsNullOrEmpty(list.ProductName))
            {
                StoreException.Error("A product must be selected");
            }
            else if (list.Quantity == 0)
            {
                StoreException.Error("Quantity must be specified");
            }
            else
            {
                list.ProductID = ProductDAL.GetProductIdWithName(list.ProductName);
                ProductListDAL.AddProductList(list, ProductLists.Count + 1);
                ProductLists.Add(list);
            }
        }

        static public void ModifyProductList(ProductList list)
        {
            if (list == null)
            {
                StoreException.Error("A product must be selected");
            }
            else if (string.IsNullOrEmpty(list.ProductName))
            {
                StoreException.Error("A product must be selected");
            }
            else if (list.Quantity == 0)
            {
                StoreException.Error("Quantity must be specified");
            }
            else
            {
                list.ProductID = ProductDAL.GetProductIdWithName(list.ProductName);
                ProductListDAL.ModifyProductList(list);
            }
        }

        static public void DeleteProductList(ProductList list)
        {
            if (list == null)
            {
                StoreException.Error("A product must be selected");
            }
            else
            {
                ProductListDAL.DeleteProductList(list);
                ProductLists.Remove(list);
            }
        }

        static public ObservableCollection<ProductList> GetAllSublists()
        {
            return ProductListDAL.GetAllProductLists();
        }
    }
}
