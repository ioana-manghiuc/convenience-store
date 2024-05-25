using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using convenience_store_.Converters_Exceptions;

namespace convenience_store_.Models.DataAccessLayer
{
    static public class ManufacturerDAL
    {
        static public ObservableCollection<Manufacturer> GetAllManufacturers()
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

        static public void AddManufacturer(Manufacturer manufacturer, int id)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand command = new SqlCommand("AddManufacturer", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCategID = new SqlParameter("@ID", id);
                SqlParameter paramCategName = new SqlParameter("@Name", manufacturer.Name);
                SqlParameter paramCategCO = new SqlParameter("@CountryOfOrigin", manufacturer.CountryOfOrigin);
                SqlParameter paramCategStatus = new SqlParameter("@IsActive", true);
                command.Parameters.Add(paramCategID);
                command.Parameters.Add(paramCategName);
                command.Parameters.Add(paramCategCO);
                command.Parameters.Add(paramCategStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static public void ModifyManufacturer(Manufacturer manufacturer)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("ModifyManufacturer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramCategID = new SqlParameter("@ID", manufacturer.ID);
                    SqlParameter paramCategName = new SqlParameter("@NewName", manufacturer.Name);
                    SqlParameter paramCategCO = new SqlParameter("@NewCountryOfOrigin", manufacturer.CountryOfOrigin);
                    command.Parameters.Add(paramCategID);
                    command.Parameters.Add(paramCategName);
                    command.Parameters.Add(paramCategCO);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
            }

        }

        static public void DeleteManufacturer(Manufacturer manufacturer)
        {
            try
            {
                using (SqlConnection connection = DALHelper.Connection)
                {
                    SqlCommand command = new SqlCommand("DeleteManufacturer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", manufacturer.ID));
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                StoreException.Error(ex.Message);
            }
        }
    }
}
