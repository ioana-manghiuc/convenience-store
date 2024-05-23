using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convenience_store_.Models.DataAccessLayer
{
    public class ManufacturerDAL
    {
        public ObservableCollection<Manufacturer> GetAllManufacturers()
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("GetAllManufacturers", connection);
                ObservableCollection<Manufacturer> result = new ObservableCollection<Manufacturer>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Manufacturer m = new Manufacturer();
                   m.ID = reader.GetInt32(0);
                    m.Name = reader.GetString(1);
                    m.CountryOfOrigin = reader.GetString(2);
                    m.IsActive = reader.GetBoolean(3);
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
        }
    }
}
