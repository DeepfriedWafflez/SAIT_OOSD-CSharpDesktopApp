using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsClasses;

namespace DBClasses
{
    /// <summary>
    /// ProductDB class object for the TravelExperts database 
    /// </summary>
    /// Author: Stuart Peters
    /// Date: March 2019
    public static class ProductSupplierDB
    {
        public static List<ProductSupplier> GetProductSuppliers()
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierID, ProductID, SupplierID " +
                                  "FROM Products_Suppliers " +
                                  "ORDER BY ProductSupplierID";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductSupplier p = new ProductSupplier();

                    p.ProductSupplierID = Convert.ToInt32(dr["ProductSupplierID"]);
                    p.ProductID = Convert.ToInt32(dr["ProductID"]);
                    p.SupplierID = Convert.ToInt32(dr["SupplierID"]);

                    ps.Add(p);
                }
            }
            catch (Exception ex)  //handle sql exceptions
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //return list
            return ps;
        }


        public static List<ProductSupplier> GetProductSuppliersByProductID(int pID)
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierID, ProductID, SupplierID " +
                                  "FROM Products_Suppliers " +
                                  "ORDER BY ProductSupplierID" +
                                  "WHERE ProductID=@ProductID";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);
            cmd.Parameters.AddWithValue("@ProductID", pID);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductSupplier p = new ProductSupplier();

                    p.ProductSupplierID = Convert.ToInt32(dr["ProductSupplierID"]);
                    p.ProductID = Convert.ToInt32(dr["ProductID"]);
                    p.SupplierID = Convert.ToInt32(dr["SupplierID"]);

                    ps.Add(p);
                }
            }
            catch (Exception ex)  //handle sql exceptions
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //return list
            return ps;
        }

        public static List<ProductSupplier> GetProductSuppliersBySupplierID(int sID)
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierID, ProductID, SupplierID " +
                                  "FROM Products_Suppliers " +
                                  "ORDER BY ProductSupplierID" +
                                  "WHERE SupplierID=@SupplierID";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);
            cmd.Parameters.AddWithValue("@SupplierID", sID);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductSupplier p = new ProductSupplier();

                    p.ProductSupplierID = Convert.ToInt32(dr["ProductSupplierID"]);
                    p.ProductID = Convert.ToInt32(dr["ProductID"]);
                    p.SupplierID = Convert.ToInt32(dr["SupplierID"]);

                    ps.Add(p);
                }
            }
            catch (Exception ex)  //handle sql exceptions
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //return list
            return ps;
        }

        //get ProductSupplier by ID
        public static ProductSupplier getProductSupplierById(int ProductSupplierID)
        {
            ProductSupplier ps = null;  //return null if no ProductSupplier exists for ID


            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierID, ProductID, SupplierID FROM Products_Suppliers " +
                                  "WHERE ProductSupplierID = @ProductSupplierID";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);

            cmd.Parameters.AddWithValue("@ProductSupplierID", ProductSupplierID);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (dr.Read())
                {
                    ps.ProductSupplierID = Convert.ToInt32(dr["ProductSupplierID"]);
                    ps.ProductID = Convert.ToInt32(dr["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(dr["SupplierID"]);

                }
            }
            catch (Exception ex)  //handle sql exceptions
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //return list
            return ps;
        }

        //Add ProductSupplier
        public static int AddProductSupplier(ProductSupplier ps)
        {
            int ProductSupplierID = 0;

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create SQL statement
            string strSqlInsert = "INSERT INTO Products_Suppliers(ProductID, SupplierID)" +
                                        "VALUES(@Product, @SupplierID)";

            //create sql command and populate parameters
            SqlCommand cmd = new SqlCommand(strSqlInsert, con);

            cmd.Parameters.AddWithValue("@ProductID", ps.ProductID);
            cmd.Parameters.AddWithValue("@SupplierID", ps.SupplierID);

            try
            {
                con.Open();
                //execute insert statement
                cmd.ExecuteNonQuery();

                //get ProductSupplier id of inserted record from database
                string strSqlSelect = "SELECT IDENT_CURRENT('Products_Suppliers') FROM Products_Suppliers";
                SqlCommand cmdSelect = new SqlCommand(strSqlSelect, con);

                ProductSupplierID = Convert.ToInt32(cmdSelect.ExecuteScalar());
            }
            catch (Exception ex)  //handle sql exceptions
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            //return result
            return ProductSupplierID;
        }

        //Update ProductSupplier
        public static bool UpdateProductSupplier(ProductSupplier oldProductSupplier, ProductSupplier newProductSupplier)
        {

            bool success = true;

            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            string strSqlUpdate = "UPDATE Products_Suppliers " +
                                  "SET ProductID = @ProductIDNew, SupplierID = @SupplierIDNew, " +
                                  "WHERE ProductSupplierID = @ProductSupplierIDOld " +  //customer id identifies record to update
                                        "AND ProductID = @ProductIDOld " +
                                        "AND SupplierID = @SupplierIDOld";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for new customer data
            cmd.Parameters.AddWithValue("@ProductIDNew", newProductSupplier.ProductID);
            cmd.Parameters.AddWithValue("@SupplierIDNew", newProductSupplier.SupplierID);

            //set parameters for old customer dat
            cmd.Parameters.AddWithValue("@ProductSupplierIDOld", oldProductSupplier.ProductSupplierID);
            cmd.Parameters.AddWithValue("@ProductIDOld", oldProductSupplier.ProductID);
            cmd.Parameters.AddWithValue("@SupplierIDOld", oldProductSupplier.SupplierID);

            try
            {
                con.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false; //did not update, most likey b/c of concurreny exception event
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return success;
        }

        //Update ProductSupplier
        public static bool DeleteProductSupplier(ProductSupplier ps)
        {

            bool success = true;

            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            string strSqlUpdate = "DELETE FROM ProductSuppliers " +
                                  "WHERE ProductSupplierID = @ProductSupplierID " +  //customer id identifies record to update
                                        "AND ProductID = @ProductID " +
                                        "AND SupplierID = @SupplierID";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for product supplier item data
            cmd.Parameters.AddWithValue("@ProductSupplierID", ps.ProductSupplierID);
            cmd.Parameters.AddWithValue("@ProductID", ps.ProductID);
            cmd.Parameters.AddWithValue("@SupplierID", ps.SupplierID);

            try
            {
                con.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false; //did not update, most likey b/c of concurreny exception event
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return success;
        }

    }
}
