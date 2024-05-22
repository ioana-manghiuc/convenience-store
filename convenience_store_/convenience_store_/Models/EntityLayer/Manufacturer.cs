using convenience_store_.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models
{
    public class Manufacturer : BasePropertyChanged
    {
        // ID, Name, CountryOfOrigin, IsActive
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

        private string countryOfOrigin;
        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set
            {
                countryOfOrigin = value;
                NotifyPropertyChanged("CountryOfOrigin");
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
