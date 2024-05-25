using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.EntityLayer
{
    public class Category : BasePropertyChanged
    {
        // ID, CategName, IsActive

        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        private string categName;
        public string CategName
        {
            get { return categName; }
            set
            {
                categName = value;
                NotifyPropertyChanged("CategName");
            }
        }

        private bool isActive;
        public bool IsActive
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
