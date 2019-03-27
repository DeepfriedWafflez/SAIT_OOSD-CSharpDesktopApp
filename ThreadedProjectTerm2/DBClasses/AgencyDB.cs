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
    * Purpose: To gather the agency table from the travel experts
    * database and load the data into a list
    * Made by: Brent Ward
    * Date: March 21th 2019
    * **/
    public static class AgencyDB
    {
        //gets the agency table from the database
        public static List<Agency> GetAgencies()
        {
            List<Agency> agencies = new List<Agency>();
            Agency agency;

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            string selectQuery = "SELECT AgencyId, AgncyAddress, AgncyCity, AgncyProv, AgncyPostal, " +
                                        "AgncyCountry, AgncyPhone, AgncyFax FROM Agencies";
            SqlCommand cmd = new SqlCommand(selectQuery, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //runs until all data has been read
                while (reader.Read())
                {
                    agency = new Agency();

                    agency.AgencyID = (int)reader["AgencyId"];
                    agency.AgencyAddress = reader["AgncyAddress"].ToString();
                    agency.AgencyCity = reader["AgncyCity"].ToString();
                    agency.AgencyProv = reader["AgncyProv"].ToString();
                    agency.AgencyPostal = reader["AgncyPostal"].ToString();
                    agency.AgencyCountry = reader["AgncyCountry"].ToString();
                    agency.AgencyFax = reader["AgncyFax"].ToString();

                    agencies.Add(agency);//adds to list
                }
            }catch(Exception e) { throw e; }
            finally { connect.Close(); }

            return agencies;
        }
    }
}
