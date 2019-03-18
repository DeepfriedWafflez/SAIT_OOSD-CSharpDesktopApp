using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClasses
{
    class TravelExpertsDBConn
    {
        public static SqlConnection getDbConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";

            //create and retrun a new sql connection object
            return new SqlConnection(connectionString);
        }

    }
}
