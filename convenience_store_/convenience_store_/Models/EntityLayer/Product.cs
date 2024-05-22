using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using convenience_store_.Models.EntityLayer;

namespace convenience_store_.Models
{
    public enum ECategory
    {
        Food,
        Beverage,
        Household,
        PersonalCare,
        Other,
        None
    }

    public class Product: BasePropertyChanged
    {
        // ID, Name, Barcode, ExpirationDate, Category, ManufacturerID, IsActive

        private int? id;
        public int? ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                NotifyPropertyChanged("Barcode");
            }
        }

        private System.DateTime? expirationDate;
        public System.DateTime? ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                expirationDate = value;
                NotifyPropertyChanged("ExpirationDate");
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public ECategory CategoryEnum
        {
            get
            {
                if (Enum.TryParse(category, out ECategory parsedCategory))
                {
                    return parsedCategory;
                }
                return ECategory.None;
            }
            set
            {
                category = value.ToString();
                NotifyPropertyChanged("Category");
            }
        }

        private int? manufacturerID;
        public int? ManufacturerID
        {
            get { return manufacturerID; }
            set
            {
                manufacturerID = value;
                NotifyPropertyChanged("ManufacturerID");
            }
        }

        private bool? isActive;
        public bool? IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                NotifyPropertyChanged("IsActive");
            }
        }
    }
}
