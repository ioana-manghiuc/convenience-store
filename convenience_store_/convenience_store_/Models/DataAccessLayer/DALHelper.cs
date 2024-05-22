using System.Configuration;
using System.Data.SqlClient;
using convenience_store_.Models;

namespace convenience_store_.Models.DataAccessLayer
{
    public static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
