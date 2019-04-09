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
    public static class PackageDB
    {
        /// <summary>
        /// GetPackage() method mentions the logic about getting all packages from the Packages table from TravelExpert database from SQL
        /// and the method is called at presentation layer on the Main form_load event.
        /// </summary>
        /// <returns>List of packages</returns>
        public static List<Package> DisplayPackagesInGrid()
        {
            List<Package> packageList = new List<Package>(); //crating empty list
            Package packageObj = null;                       //referencing package object

            string selectQuery = "SELECT * FROM Packages ORDER BY PkgName ASC";   //SQL query to get all fields from table

            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();                             //databse connection opens
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            packageObj = new Package();         //instantiating the object of the class Package      
                            packageObj.PackageId = (int)dr["PackageId"];
                            packageObj.PkgName = (string)dr["PkgName"];
                            packageObj.PkgStartDate = dr["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dr["PkgStartDate"];
                            packageObj.PkgEndDate = dr["PkgEndDate"] == DBNull.Value ? null : (DateTime?)dr["PkgEndDate"];
                            packageObj.PkgDesc = dr["PkgDesc"] == DBNull.Value ? null : (string)dr["PkgDesc"];
                            packageObj.PkgBasePrice = double.Parse(dr["PkgBasePrice"].ToString());

                            packageObj.PkgAgencyCommission = dr["PkgAgencyCommission"] == DBNull.Value ? Convert.ToDouble(null) : double.Parse(dr["PkgAgencyCommission"].ToString());
                            packageList.Add(packageObj);        //adding package items into the list 
                        }
                    }
                    return packageList;                         //returns the list of package
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SearchByText() method has the logic to search the package on the form by its name.
        /// </summary>
        /// <param name="searchText which is passed from the form and taken by SQL query as parameter "></param>
        /// <returns>list of package matching the wildcard from the SQL query</returns>

        public static List<Package> SearchByText(string searchText)
        {
            List<Package> packageList = new List<Package>(); //crating empty list
            Package packageObj = null;                       //referencing package object
            string selectQuery = "SELECT * FROM Packages where PkgName LIKE '%" + searchText + "%' ORDER BY PkgName ASC";   //SQL query to get all fields from table

            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();                             //databse connection opens
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            packageObj = new Package();         //instantiating the object of the class Package      
                            packageObj.PackageId = (int)dr["PackageId"];
                            packageObj.PkgName = (string)dr["PkgName"];
                            packageObj.PkgStartDate = dr["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dr["PkgStartDate"];
                            packageObj.PkgEndDate = dr["PkgEndDate"] == DBNull.Value ? null : (DateTime?)dr["PkgEndDate"];
                            packageObj.PkgDesc = dr["PkgDesc"] == DBNull.Value ? null : (string)dr["PkgDesc"];
                            packageObj.PkgBasePrice = double.Parse(dr["PkgBasePrice"].ToString());

                            packageObj.PkgAgencyCommission = dr["PkgAgencyCommission"] == DBNull.Value ? Convert.ToDouble(null) : double.Parse(dr["PkgAgencyCommission"].ToString());
                            packageList.Add(packageObj);        //adding package items into the list 
                        }
                    }
                    return packageList;                         //returns the list of package
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// this method contains the logic to add the package by the user form the package form 
        /// </summary>
        /// <param name="it passes the entire package object as parameter so that all information inside the object can be added"></param>
        public static void PackageAdd(Package pkgObj)
        {
            string insertStatement = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission) " +
                                    "VALUES (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission) ";

            try
            {
          
                using (SqlConnection con = TravelExpertsDBConn.getDbConnection()) //doesn't require to close connection as USING method doest it by itself
                {
                    using (SqlCommand cmd = new SqlCommand(insertStatement, con))
                    {
                        con.Open();                             //databse connection opens
                  //    cmd.Parameters.AddWithValue("@PackageId", pkgObj.PackageId);  //auto-generated                                      
                        cmd.Parameters.AddWithValue("@PkgName", pkgObj.PkgName);  
                        cmd.Parameters.AddWithValue("@PkgBasePrice", pkgObj.PkgBasePrice);
                        if (pkgObj.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgStartDate", pkgObj.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);

                        if (pkgObj.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);

                        if (pkgObj.PkgDesc != null)
                        {
                            cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);
                        }
                        else cmd.Parameters.AddWithValue("@PkgDesc","");

                        if (pkgObj.PkgAgencyCommission.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);
                        }
                        else cmd.Parameters.AddWithValue("@PkgAgencyCommission", 0);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// this method contains the logic to save the updated record in the database.
        /// </summary>
        /// <param name="package"></param>
        /// <param name="here 2 parameters are passed in, 1st one is old package object which is already ther in the database
        /// and 2nd one is new package object which contains updated information from the package form"></param>
        /// <returns>it returns the boolean(true/false), true if update is successful and false if not</returns>

        public static bool PackageUpdate(Package package,Package newPackage)
        {
            bool result = true;

            string updateStatement = "UPDATE Packages SET  PkgName = @newPkgName, " +
                                      "PkgStartDate = @newPkgStartDate, " +
                                     "PkgEndDate = @newPkgEndDate, " +
                                     "PkgDesc = @newPkgDesc, " +
                                     "PkgBasePrice=@newPkgBasePrice, " +
                                     "PkgAgencyCommission = @newPkgAgencyCommission " +
                                     "WHERE PackageId = @oldPackageId ";
                                     //"AND PkgName = @oldPkgName " +
                                     //"AND PkgStartDate = @oldPkgStartDate " +
                                     //"AND PkgEndDate = @oldPkgEndDate " +
                                     //"AND PkgDesc = @oldPkgDesc " +
                                     //"AND PkgBasePrice=@oldPkgBasePrice " +
                                     //"AND PkgAgencyCommission = @oldPkgAgencyCommission"; 
                                     

            try
            {
                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(updateStatement, con))
                    {
                        con.Open();
                        //cmd.Parameters.AddWithValue("@PackageId", newPackage.PackageId);
                        cmd.Parameters.AddWithValue("@newPkgName", newPackage.PkgName);
                        cmd.Parameters.AddWithValue("@newPkgBasePrice", newPackage.PkgBasePrice);
                        if (newPackage.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@newPkgStartDate", newPackage.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@newPkgStartDate", DBNull.Value);

                        if (newPackage.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@newPkgEndDate", newPackage.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@newPkgEndDate", DBNull.Value);

                        if (newPackage.PkgDesc == null)
                        {
                            cmd.Parameters.AddWithValue("@newPkgDesc", "");
                        }
                        else cmd.Parameters.AddWithValue("@newPkgDesc", newPackage.PkgDesc);

                        if (newPackage.PkgAgencyCommission == null)
                        {
                            cmd.Parameters.AddWithValue("@newPkgAgencyCommission", 0);
                        }
                        else 
                        cmd.Parameters.AddWithValue("@newPkgAgencyCommission", newPackage.PkgAgencyCommission);

                        cmd.Parameters.AddWithValue("@oldPackageId", package.PackageId);
                        cmd.Parameters.AddWithValue("@oldPkgName", package.PkgName);
                        cmd.Parameters.AddWithValue("@oldPkgBasePrice", package.PkgBasePrice);
                        if (package.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgStartDate", package.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgStartDate", DBNull.Value);

                        if (package.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgEndDate", package.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgEndDate", DBNull.Value);

                        if (package.PkgDesc == null)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgDesc", "");
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgDesc",package.PkgDesc);

                        if (package.PkgAgencyCommission == null)
                        {
                            cmd.Parameters.AddWithValue("@oldPkgAgencyCommission", package.PkgAgencyCommission);
                        }
                        else cmd.Parameters.AddWithValue("@oldPkgAgencyCommission", 0);

                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated == 0) result = false; // did not update (another user updated or deleted)
                    }
                    

                    return result;
                }
            }
            catch (DBConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// this below method has the logic of deleting the selected package information. it also takes care of database concurrancy
        /// </summary>
        /// <param name="the entire package object is passed as parameter as it contains all information to be deleted"></param>
        /// <returns>it returns the boolean(true/false), true if delete is successful and false if not</returns>

        public static bool PackageDelete(Package pkgObj)
        { 
            bool result = true;

            string deleteStatement = "DELETE FROM Packages WHERE PackageId = @PackageId " +
                                    "AND PkgName = @PkgName " +
                                    "AND (PkgDesc = @PkgDesc OR @PkgDesc is NULL AND PkgDesc is NULL)  " +
                                    "AND (PkgStartDate = @PkgStartDate OR @PkgStartDate is NULL AND PkgStartDate is NULL) " +
                                    "AND (PkgEndDate = @PkgEndDate OR @PkgEndDate is NULL AND PkgEndDate is NULL) " +
                                    "AND PkgBasePrice = @PkgBasePrice "+
                                    "AND (PkgAgencyCommission = @PkgAgencyCommission OR @PkgAgencyCommission is NULL AND PkgAgencyCommission is NULL)";
            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(deleteStatement, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@PackageId", pkgObj.PackageId);
                        cmd.Parameters.AddWithValue("@PkgName", pkgObj.PkgName);
                        cmd.Parameters.AddWithValue("@PkgBasePrice", pkgObj.PkgBasePrice);
                        if (pkgObj.PkgStartDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgStartDate", pkgObj.PkgStartDate);
                        }
                        else cmd.Parameters.AddWithValue("@PkgStartDate", DBNull.Value);

                        if (pkgObj.PkgEndDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                        }
                        else cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);

                        if (String.IsNullOrEmpty(pkgObj.PkgDesc))
                        {
                            cmd.Parameters.AddWithValue("@PkgDesc", "");
                        }
                        else cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);

                        if (pkgObj.PkgAgencyCommission.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);
                        }
                        else cmd.Parameters.AddWithValue("@PkgAgencyCommission", 0);

                         

                        int count = cmd.ExecuteNonQuery();
                        if (count == 0) // optimistic concurrency violation
                            result = false;
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// below method has the logic to check if the selected package information to be deleted has any child dependency to be checked
        /// </summary>
        /// <returns>it returns the list of name of the package which is used to compare and show appropriate message to the user on the package form</returns>

        public static List<string> CheckBeforeDelete()
        {
            List<string> packageNames = new List<string>();

            string query = "SELECT PackageId,PkgName from packages Where Not EXISTS " +
                            "(SELECT b.packageid, p.packageid from bookings b,Packages_Products_Suppliers p where b.packageid=p.packageid)";
            try
            {
                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();                             //databse connection opens
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            packageNames.Add(Convert.ToString(dr["PkgName"]));
                        }
                    }
                    return packageNames;                         //returns the list of package
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// this method displays the related booking in the booking data grid on the Package form
        /// </summary>
        /// <param name="PackageId is passed as parameter to use it in SQL query to fetch correct records"></param>
        /// <returns>list of related bookings for the selected package</returns>


        public static List<Bookings> DisplayBookingsInGrid(int pkgId)
        {
            List<Bookings> bookingList = new List<Bookings>();

            string selectQuery = "select BookingNo,CustomerId,TripTypeId from bookings where PackageId IN (Select PackageId from packages WHERE PackageId=@pkgId) ";   //SQL query to get all fields from table

            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();//databse connection opens
                        cmd.Parameters.AddWithValue("@pkgId", pkgId); //binding it with PkgId parameter which is passed on in an arguement

                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            Bookings bkngObj = new Bookings();         //instantiating the object of the class booking      

                            bkngObj.BookingNo = (string)dr["BookingNo"];
                            bkngObj.CustomerId = (int)dr["CustomerId"];
                            bkngObj.TripTypeId = (string)dr["TripTypeId"];

                            bookingList.Add(bkngObj);        //adding booking items into the list 
                        }
                    }
                    return bookingList;                         //returns the list of booking
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Product> DisplayProductsInList(int pkgId)
        {
            List<Product> productList = new List<Product>(); //crating empty list
            Product productObj = null;                       //referencing product object

            string selectQuery = "SELECT p.ProductId as 'product',p.ProdName,ps.ProductSupplierId " +   //SQL query to get all fields from table
                                "FROM Products p " +
                                "INNER JOIN Products_Suppliers ps " +
                                "ON  p.ProductId = ps.ProductId " +
                                "INNER JOIN Packages_Products_Suppliers pps " +
                                "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                "INNER JOIN Packages pk " +
                                "ON pps.PackageId = pk.PackageId  WHERE pk.PackageId = @pkgId";

            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();                             //databse connection opens
                        cmd.Parameters.AddWithValue("@pkgId", pkgId); //binding it with PkgId parameter which is passed on in an arguement
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            productObj = new Product();         //instantiating the object of the class Product      
                            productObj.ProdName = (string)dr["ProdName"];
                           
                            productList.Add(productObj);        //adding product items into the list 
                        }
                    }
                    return productList;                         //returns the list of product
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Supplier> DisplaySuppliersInList(int pkgId)
        {
            List<Supplier> supplierList = new List<Supplier>(); //crating empty list
            Supplier supplierObj = null;                       //referencing supplier object

            string selectQuery = "SELECT s.SupplierId as 'supplier',s.SupName,ps.ProductSupplierId " +
                                "FROM Suppliers s " +
                                "INNER JOIN Products_Suppliers ps " +
                                "ON s.SupplierId = ps.SupplierId " +
                                "INNER JOIN Packages_Products_Suppliers pps " +
                                "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                "INNER JOIN Packages pk " +
                                "ON pps.PackageId = pk.PackageId  WHERE pk.PackageId = @pkgId";

            try
            {

                using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                    {
                        con.Open();                             //databse connection opens
                        cmd.Parameters.AddWithValue("@pkgId", pkgId); //binding it with PkgId parameter which is passed on in an arguement
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
                        while (dr.Read())                       //below block of code executes till there is data in the table
                        {
                            supplierObj = new Supplier();         //instantiating the object of the class Supplier      
                            supplierObj.SupName = (string)dr["SupName"];

                            supplierList.Add(supplierObj);        //adding supplier items into the list 
                        }
                    }
                    return supplierList;                         //returns the list of suppliers
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }









    }//class
} //namespace

/// <summary>
/// GetPackageById() is the method which brings the relevant package information to show in the form based on gridrow selected by user
/// </summary>
/// <param name="packageId"></param>
/// <returns>list of package</returns>
//public static List<Package> GetPackageById(int packageId)
//{
//    List<Package> packageList = new List<Package>(); //creating empty list
//    Package packageObj = null;

//    string selectStatement = "SELECT * FROM Packages WHERE PackageId = @packageId";

//    using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
//    {
//        using (SqlCommand cmd = new SqlCommand(selectStatement, con))
//        {
//            con.Open();                             //databse connection opens
//            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //Data reader executes the query and bring all data before closing connection to the table
//            while (dr.Read())                       //below block of code executes till there is data in the table
//            {
//                packageObj = new Package();         //instantiating the object of the class Package because  
//                packageObj.PackageId = (int)dr["PackageId"];
//                packageObj.PkgName = (string)dr["PkgName"];
//                packageObj.PkgStartDate = dr["PkgStartDate"] == DBNull.Value ? null : (DateTime?)dr["PkgStartDate"];
//                packageObj.PkgEndDate = dr["PkgEndDate"] == DBNull.Value ? null : (DateTime?)dr["PkgEndDate"];
//                packageObj.PkgDesc = dr["PkgDesc"] == DBNull.Value ? null : (string)dr["PkgDesc"];
//                packageObj.PkgBasePrice = double.Parse(dr["PkgBasePrice"].ToString());
//                packageObj.PkgAgencyCommission = dr["PkgAgencyCommission"] == DBNull.Value ? 0 : double.Parse(dr["PkgAgencyCommission"].ToString());
//                packageList.Add(packageObj);        //adding package items into the list 
//            }
//        }
//        return packageList;
//    }
//}