using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsClasses;

namespace DBClasses
{
    /**
     * Threaded project 2 - Team 1
     * Purpose: To gather the supplier table from the travel experts
     * database and load the data into a list
     * Made by: Brent Ward
     * Date: March 12th 2019
     * **/
    public static class SuppliersDB
    {
        //grabs the suppliers
        public static List<Supplier> GetSuppliers()
        {
            //List and holder created
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supplierHolder;

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();//defines db connection
            string selectQuery = "SELECT SupplierID, SupName FROM Suppliers ORDER BY SupplierID";
            SqlCommand cmd = new SqlCommand(selectQuery, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //runs until all data has been read
                while (reader.Read())
                {
                    supplierHolder = new Supplier();
                    supplierHolder.SupID = (int)reader["SupplierID"];
                    supplierHolder.SupName = reader["SupName"].ToString();

                    suppliers.Add(supplierHolder);//adds to list
                }

            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }

            return suppliers;//returns the list
        }


        //adds a supplier
        public static void AddSupplier(Supplier supp)
        {
            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            string insertQuery = "INSERT INTO Suppliers (SupplierID, SupName) VALUES(@SupplierID, @SupName)";
            SqlCommand cmd = new SqlCommand(insertQuery, connect);

            //applies the values to the query
            cmd.Parameters.AddWithValue("@SupplierID", supp.SupID);
            cmd.Parameters.AddWithValue("@SupName", supp.SupName);

            try
            {
                connect.Open();
            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }
        }



        //deletes a supplier
        public static bool DeleteSupplier(Supplier supp)
        {
            bool success = true;//sets up return value

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            string deleteQuery = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID AND SupName = @SupName";
            SqlCommand cmd = new SqlCommand(deleteQuery, connect);

            //inputs the parameters to check them
            cmd.Parameters.AddWithValue("@SupplierID", supp.SupID);
            cmd.Parameters.AddWithValue("@SupName", supp.SupName);

            try
            {
                connect.Open();
                int count = cmd.ExecuteNonQuery();
                if (count == 0) success = false;
            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }

            return success;
        }
    }
}
