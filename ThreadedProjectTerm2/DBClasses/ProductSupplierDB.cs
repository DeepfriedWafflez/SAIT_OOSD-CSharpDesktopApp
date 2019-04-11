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

        //get list of ProductSuppliers from database
        public static List<ProductSupplier> GetProductSuppliers()
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierId, ProductId, SupplierId " +
                                  "FROM Products_Suppliers " +
                                  "ORDER BY ProductSupplierId";

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

                    p.ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"]);
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.SupplierId = Convert.ToInt32(dr["SupplierId"]);

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

        //get list of ProductSuppliers from database for a given product id
        public static List<ProductSupplier> GetProductSuppliersByProductID(int pId)
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierId, ProductId, SupplierId " +
                                  "FROM Products_Suppliers " +
                                  "WHERE ProductId=@ProductId";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);
            cmd.Parameters.AddWithValue("@ProductId", pId);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductSupplier p = new ProductSupplier();

                    p.ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"]);
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.SupplierId = Convert.ToInt32(dr["SupplierId"]);

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


        //get list of ProductSuppliers from database for a given supplier id
        public static List<ProductSupplier> GetProductSuppliersBySupplierID(int sId)
        {
            List<ProductSupplier> ps = new List<ProductSupplier>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierId, ProductId, SupplierId " +
                                  "FROM Products_Suppliers " +
                                  "ORDER BY ProductSupplierId" +
                                  "WHERE SupplierId=@SupplierId";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);
            cmd.Parameters.AddWithValue("@SupplierId", sId);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductSupplier p = new ProductSupplier();

                    p.ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"]);
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.SupplierId = Convert.ToInt32(dr["SupplierId"]);

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

        //get ProductSupplier by Id
        public static ProductSupplier getProductSupplierById(int ProductSupplierId)
        {
            ProductSupplier ps = null;  //return null if no ProductSupplier exists for Id


            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductSupplierId, ProductId, SupplierId FROM Products_Suppliers " +
                                  "WHERE ProductSupplierId = @ProductSupplierId";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);

            cmd.Parameters.AddWithValue("@ProductSupplierId", ProductSupplierId);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (dr.Read())
                {
                    ps = new ProductSupplier();

                    ps.ProductSupplierId = Convert.ToInt32(dr["ProductSupplierId"]);
                    ps.ProductId = Convert.ToInt32(dr["ProductId"]);
                    ps.SupplierId = Convert.ToInt32(dr["SupplierId"]);

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
            int ProductSupplierId = 0;

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create SQL statement
            string strSqlInsert = "INSERT INTO Products_Suppliers(ProductId, SupplierId)" +
                                        "VALUES(@ProductId, @SupplierId)";

            //create sql command and populate parameters
            SqlCommand cmd = new SqlCommand(strSqlInsert, con);

            cmd.Parameters.AddWithValue("@ProductId", ps.ProductId);
            cmd.Parameters.AddWithValue("@SupplierId", ps.SupplierId);

            try
            {
                con.Open();
                //execute insert statement
                cmd.ExecuteNonQuery();

                //get ProductSupplier Id of inserted record from database
                string strSqlSelect = "SELECT IDENT_CURRENT('Products_Suppliers') FROM Products_Suppliers";
                SqlCommand cmdSelect = new SqlCommand(strSqlSelect, con);

                ProductSupplierId = Convert.ToInt32(cmdSelect.ExecuteScalar());
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
            return ProductSupplierId;
        }

        //Update ProductSupplier
        public static bool UpdateProductSupplier(ProductSupplier oldProductSupplier, ProductSupplier newProductSupplier)
        {

            bool success = true;

            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            string strSqlUpdate = "UPDATE Products_Suppliers " +
                                  "SET ProductId = @ProductIdNew, SupplierId = @SupplierIdNew, " +
                                  "WHERE ProductSupplierId = @ProductSupplierIdOld " +  //customer Id Identifies record to update
                                        "AND ProductId = @ProductIdOld " +
                                        "AND SupplierId = @SupplierIdOld";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for new customer data
            cmd.Parameters.AddWithValue("@ProductIdNew", newProductSupplier.ProductId);
            cmd.Parameters.AddWithValue("@SupplierIdNew", newProductSupplier.SupplierId);

            //set parameters for old customer dat
            cmd.Parameters.AddWithValue("@ProductSupplierIdOld", oldProductSupplier.ProductSupplierId);
            cmd.Parameters.AddWithValue("@ProductIdOld", oldProductSupplier.ProductId);
            cmd.Parameters.AddWithValue("@SupplierIdOld", oldProductSupplier.SupplierId);

            try
            {
                con.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false; //dId not update, most likey b/c of concurreny exception event
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

            string strSqlUpdate = "DELETE FROM Products_Suppliers " +
                                  "WHERE ProductSupplierId = @ProductSupplierId " +  //customer Id Identifies record to update
                                        "AND ProductId = @ProductId " +
                                        "AND SupplierId = @SupplierId";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for product supplier item data
            cmd.Parameters.AddWithValue("@ProductSupplierId", ps.ProductSupplierId);
            cmd.Parameters.AddWithValue("@ProductId", ps.ProductId);
            cmd.Parameters.AddWithValue("@SupplierId", ps.SupplierId);

            try
            {
                con.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false; //dId not update, most likey b/c of concurreny exception event
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
