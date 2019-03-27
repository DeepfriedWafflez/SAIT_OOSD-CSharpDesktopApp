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

            string selectQuery = "SELECT * FROM Packages";   //SQL query to get all fields from table

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
                        packageObj.PkgAgencyCommission = dr["PkgAgencyCommission"] == DBNull.Value ? 0 : double.Parse(dr["PkgAgencyCommission"].ToString());
                        packageList.Add(packageObj);        //adding package items into the list 
                    }
                }
                return packageList;                         //returns the list of package
            }

        }

       
        public static void PackageAdd(Package pkgObj)
        {
            string insertStatement = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission) " +
                                    "VALUES (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission) ";
                                    
            using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
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

                    if (pkgObj.PkgStartDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                    }
                    else cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);

                    if (pkgObj.PkgDesc != null)
                    {
                        cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);
                    }
                    else cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);

                    if (pkgObj.PkgAgencyCommission.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);
                    }
                    else cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool PackageUpdate(Package pkgObj)
        {
            bool result = true;

            string updateStatement = "UPDATE Packages SET  PkgName = @PkgName, PkgStartDate = @PkgStartDate, " +
                                     "PkgEndDate = @PkgEndDate, PkgDesc=@PkgDesc, PkgBasePrice=@PkgBasePrice, " +
                                     "PkgAgencyCommission=@PkgAgencyCommission " +
                                     "WHERE PackageId = @PackageId";
                                     

            using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
            {
                using (SqlCommand cmd = new SqlCommand(updateStatement, con))
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

                    if (pkgObj.PkgStartDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                    }
                    else cmd.Parameters.AddWithValue("@PkgEndDate", DBNull.Value);

                    if (pkgObj.PkgDesc != null)
                    {
                        cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);
                    }
                    else cmd.Parameters.AddWithValue("@PkgDesc", DBNull.Value);

                    if (pkgObj.PkgAgencyCommission.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);
                    }
                    else cmd.Parameters.AddWithValue("@PkgAgencyCommission", DBNull.Value);

                    //cmd.Parameters.AddWithValue("@PackageId", oldPkgObj.PackageId);
                    //cmd.Parameters.AddWithValue("@PkgName", oldPkgObj.PkgName);
                    //cmd.Parameters.AddWithValue("@PkgStartDate", oldPkgObj.PkgStartDate);
                    //cmd.Parameters.AddWithValue("@PkgEndDate", oldPkgObj.PkgEndDate);
                    //cmd.Parameters.AddWithValue("@PkgDesc", oldPkgObj.PkgDesc);
                    //cmd.Parameters.AddWithValue("@PkgAgencyCommission", oldPkgObj.PkgAgencyCommission);

                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated == 0) result = false; // did not update (another user updated or deleted)
                }
            }

            return result;
        }


        public static bool PackageDelete(Package pkgObj)
        {
            
            bool result = true;

            string deleteStatement = "DELETE FROM Packages WHERE PackageId = @packageId "+
                                    "AND PkgName = @PkgName " +
                                    "AND PkgDesc = @PkgDesc " +
                                    "AND PkgStartDate = @PkgStartDate " +
                                    "AND PkgEndDate = @PkgEndDate " +
                                    "AND PkgBasePrice = @PkgBasePrice " +
                                    "AND PkgAgencyCommission = @PkgAgencyCommission";

            using (SqlConnection con = TravelExpertsDBConn.getDbConnection())
            {
                using (SqlCommand cmd = new SqlCommand(deleteStatement, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@PackageId", pkgObj.PackageId);
                    cmd.Parameters.AddWithValue("@PkgName", pkgObj.PkgName);
                    cmd.Parameters.AddWithValue("@PkgBasePrice", pkgObj.PkgBasePrice);
                    cmd.Parameters.AddWithValue("@PkgStartDate", pkgObj.PkgStartDate);
                    cmd.Parameters.AddWithValue("@PkgEndDate", pkgObj.PkgEndDate);
                    cmd.Parameters.AddWithValue("@PkgDesc", pkgObj.PkgDesc);
                    cmd.Parameters.AddWithValue("@PkgAgencyCommission", pkgObj.PkgAgencyCommission);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 0) // optimistic concurrency violation
                        result = false;
                }
            }
            return result;
        }
            
        
        public static List<string> CheckBeforeDelete()
        {
            List<string> packageNames = new List<string>();

            string query = "SELECT PackageId,PkgName from packages Where  EXISTS " +
                            "(SELECT b.packageid, p.packageid from bookings b,Packages_Products_Suppliers p where b.packageid=p.packageid)";

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