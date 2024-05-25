using convenience_store_.Converters_Exceptions;
using convenience_store_.Models.DataAccessLayer;
using System.Collections.ObjectModel;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models.BusinessLogicLayer
{
    static public class ManufacturerBLL
    {
        static public ObservableCollection<Manufacturer> ManufacturerList { get; set; }

        static public ObservableCollection<Manufacturer> GetAllManufacturers()
        {
            return ManufacturerDAL.GetAllManufacturers();
        }

        static public void AddManufacturer(Manufacturer manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer.Name))
            {
                StoreException.Error("Manufacturer name must be specified");
            }
            else
            {
                ManufacturerDAL.AddManufacturer(manufacturer, ManufacturerList.Count + 1);
                ManufacturerList.Add(manufacturer);
            }
        }

        static public void ModifyManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                StoreException.Error("A manufacturer must be selected");
            }
            else if (string.IsNullOrEmpty(manufacturer.Name))
            {
                StoreException.Error("Manufacturer name must be specified");
            }
            else
            {
                ManufacturerDAL.ModifyManufacturer(manufacturer);
            }
        }

        static public void DeleteManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                StoreException.Error("A manufacturer must be selected");
            }
            else
            {
                ManufacturerDAL.DeleteManufacturer(manufacturer);
            }
        }
    }
}
