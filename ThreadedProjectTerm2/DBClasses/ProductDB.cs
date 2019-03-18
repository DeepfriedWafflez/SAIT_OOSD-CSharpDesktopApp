﻿using System;
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
    public class ProductDB
    {
        //get Products
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();  //empty list

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductID, ProdName FROM Products ORDER BY ProdName";



            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);

            //try-catch sql command execution
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product p = new Product();

                    p.ProductID = Convert.ToInt32(dr["ProductID"]);
                    p.ProdName = dr["ProdName"].ToString();

                    products.Add(p);
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
            return products;
        }


        //get Product by ID
        public static Product getProductById(int productID)
        {
            Product p = null;  //return null if no product exists for ID


            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create sql statement
            string strSqlSelect = "SELECT ProductID, ProdName FROM Products " +
                                  "WHERE ProductID = @ProductID";

            //create sql command
            SqlCommand cmd = new SqlCommand(strSqlSelect, con);

            cmd.Parameters.AddWithValue("@ProductID", productID);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (dr.Read())
                {
                    p.ProductID = Convert.ToInt32(dr["ProductID"]);
                    p.ProdName = dr["ProdName"].ToString();
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
            return p;
        }

        //Add Product
        public static int AddProduct(Product p)
        {
            int productID = 0;

            //create connection
            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            //create SQL statement
            string strSqlInsert = "INSERT INTO Products(ProdName)" +
                                        "VALUES(@ProdName)";

            //create sql command and populate parameters
            SqlCommand cmd = new SqlCommand(strSqlInsert, con);

            cmd.Parameters.AddWithValue("@ProdName", p.ProdName);

            try
            {
                con.Open();
                //execute insert statement
                cmd.ExecuteNonQuery();

                //get product id of inserted record from database
                string strSqlSelect = "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand cmdSelect = new SqlCommand(strSqlSelect, con);

                productID = Convert.ToInt32(cmdSelect.ExecuteScalar());
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
            return productID;
        }

        //Update Product
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {

            bool success = true;

            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            string strSqlUpdate = "UPDATE Products " +
                                    "SET ProdName = @ProdNameNew, " +
                                    "WHERE ProductID = @ProductIDOld " +  //customer id identifies record to update
                                        "AND ProdName = @ProdNameOld";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for new customer data
            cmd.Parameters.AddWithValue("@ProdNameNew", newProduct.ProdName);

            //set parameters for old customer dat
            cmd.Parameters.AddWithValue("@ProductIDOld", oldProduct.ProductID);
            cmd.Parameters.AddWithValue("@ProdNameOld", oldProduct.ProdName);

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

        //Update Product
        public static bool DeleteProduct(Product p)
        {

            bool success = true;

            SqlConnection con = TravelExpertsDBConn.getDbConnection();

            string strSqlUpdate = "DELETE FROM Products " +
                                  "WHERE ProductID = @ProductID " +  //customer id identifies record to update
                                   "AND ProdName = @ProdName";

            SqlCommand cmd = new SqlCommand(strSqlUpdate, con);

            //set parameters for old customer dat
            cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
            cmd.Parameters.AddWithValue("@ProdName", p.ProdName);

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
