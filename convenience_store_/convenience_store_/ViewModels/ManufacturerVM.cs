using convenience_store_.Models;
using convenience_store_.Models.BusinessLogicLayer;
using convenience_store_.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace convenience_store_.ViewModels
{
    public class ManufacturerVM : BasePropertyChanged
    {
        public ManufacturerVM()
        {
            ManufacturerList = ManufacturerBLL.GetAllManufacturers();
        }

        public ObservableCollection<Manufacturer> ManufacturerList
        {
            get => ManufacturerBLL.ManufacturerList;
            set => ManufacturerBLL.ManufacturerList = value;
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Manufacturer>(ManufacturerBLL.AddManufacturer);
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
                    modifyCommand = new RelayCommand<Manufacturer>(ManufacturerBLL.ModifyManufacturer);
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
                    deleteCommand = new RelayCommand<Manufacturer>(ManufacturerBLL.DeleteManufacturer);
                }
                return deleteCommand;
            }
        }
    }
}
