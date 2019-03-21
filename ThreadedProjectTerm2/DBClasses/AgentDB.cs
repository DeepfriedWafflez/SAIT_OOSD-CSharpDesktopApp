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
    * Purpose: To gather the agent table from the travel experts
    * database and load the data into a list
    * Made by: Brent Ward
    * Date: March 12th 2019
    * **/
    public static class AgentDB
    {
        //grabs the agents
        public static List<Agent> GetAgents()
        {
            //list and holder created
            List<Agent> agents = new List<Agent>();
            Agent agentHolder;

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();//defines db connection
            string selectQuery = "SELECT AgentId, AgtFirstName, AgtMiddleInitial, AgtLastName," +
                                    "AgtBusPhone, AgtEmail, AgtPosition, AgencyId FROM agents";
            SqlCommand cmd = new SqlCommand(selectQuery, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //runs until all data has been read
                while (reader.Read())
                {
                    agentHolder = new Agent();

                    agentHolder.AgentID = (int)reader["AgentId"];
                    agentHolder.AgtFirstName = reader["AgtFirstName"].ToString();
                    agentHolder.AgtLastName = reader["AgtLastName"].ToString();
                    agentHolder.AgtMiddleInitial = reader["AgtMiddleInitial"].ToString();
                    agentHolder.AgtBusPhone = reader["AgtBusPhone"].ToString();
                    agentHolder.AgtEmail = reader["AgtEmail"].ToString();
                    agentHolder.AgtPosition = reader["AgtPosition"].ToString();
                    agentHolder.AgencyID = (int)reader["AgencyId"];

                    agents.Add(agentHolder);//adds to list
                }

            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }

            return agents;
        }


        //adds an agent
        public static int AddAgent(Agent agt)
        {
            int agentID = 0;

            //Opens connection to the DB and preps insert
            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            string insertQuery = "INSERT INTO Agents (AgtFirstName, AgtLastName, AgtMiddleInitial, AgtBusPhone," +
                                            "AgtEmail, AgtPosition, AgencyId) VALUES(@AgtFirstName, @AgtLastName," +
                                            "@AgtMiddleInitial, @AgtBusPhone, @AgtEmail, @AgtPosition, @AgencyId)";
            SqlCommand cmd = new SqlCommand(insertQuery, connect);

            //applies the value to the query
            cmd.Parameters.AddWithValue("@AgtFirstName", agt.AgtFirstName);
            cmd.Parameters.AddWithValue("@AgtLastName", agt.AgtLastName);
            cmd.Parameters.AddWithValue("@AgtMiddleInitial", agt.AgtMiddleInitial);
            cmd.Parameters.AddWithValue("@AgtBusPhone", agt.AgtBusPhone);
            cmd.Parameters.AddWithValue("@AgtEmail", agt.AgtEmail);
            cmd.Parameters.AddWithValue("@AgtPosition", agt.AgtPosition);
            cmd.Parameters.AddWithValue("@AgencyId", agt.AgencyID);

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                string selectQuery = "SELECT IDENT_CURRENT('Agents') FROM Agents"; //identity value
                SqlCommand selectCommand = new SqlCommand(selectQuery, connect);
                agentID = Convert.ToInt32(selectCommand.ExecuteScalar()); //single value
                agt.AgentID = agentID;

            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }

            return agentID;
        }


        //updates an agent
        public static bool UpdateAgent(Agent oldAgent, Agent newAgent)
        {
            bool success = true;

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            //only needs ID, rest checks for concurrency issues
            string updateQuery = "UPDATE Agents SET AgtFirstName = @NewAgtFirstName, " +
                                                "AgtMiddleInitial = @NewAgtMiddleInitial, " +
                                                "AgtLastName = @NewAgtLastName, " +
                                                "AgtBusPhone = @NewAgtBusPhone, " +
                                                "AgtEmail = @NewAgtEmail, " +
                                                "AgtPosition = @newAgtPosition, " +
                                                "AgencyId = @NewAgencyId " +
                                 "WHERE AgentId = @OldAgentId " +
                                       "AND AgtFirstName = @OldAgtFirstName " +
                                       "AND AgtMiddleInitial = @OldAgtMiddleInitial " +
                                       "AND AgtLastName = @OldAgtLastName " +
                                       "AND AgtBusPhone = @OldAgtBusPhone " +
                                       "AND AgtEmail = @OldAgtEmail " +
                                       "AND AgtPosition = @OldAgtPosition "+
                                       "AND AgencyId = @OldAgencyId";
            SqlCommand cmd = new SqlCommand(updateQuery, connect);

            //sets the parameters
            cmd.Parameters.AddWithValue("@NewAgtFirstName", newAgent.AgtFirstName);
            cmd.Parameters.AddWithValue("@NewAgtMiddleInitial", newAgent.AgtMiddleInitial);
            cmd.Parameters.AddWithValue("@NewAgtLastName", newAgent.AgtLastName);
            cmd.Parameters.AddWithValue("@NewAgtBusPhone", newAgent.AgtBusPhone);
            cmd.Parameters.AddWithValue("@NewAgtEmail", newAgent.AgtEmail);
            cmd.Parameters.AddWithValue("@NewAgtPosition", newAgent.AgtPosition);
            cmd.Parameters.AddWithValue("@NewAgencyId", newAgent.AgencyID);

            cmd.Parameters.AddWithValue("@OldAgentId", oldAgent.AgentID);
            cmd.Parameters.AddWithValue("@OldAgtFirstName", oldAgent.AgtFirstName);
            cmd.Parameters.AddWithValue("@OldAgtMiddleInitial", oldAgent.AgtMiddleInitial);
            cmd.Parameters.AddWithValue("@OldAgtLastName", oldAgent.AgtLastName);
            cmd.Parameters.AddWithValue("@OldAgtBusPhone", oldAgent.AgtBusPhone);
            cmd.Parameters.AddWithValue("@OldAgtEmail", oldAgent.AgtEmail);
            cmd.Parameters.AddWithValue("@OldAgtPosition", oldAgent.AgtPosition);
            cmd.Parameters.AddWithValue("@OldAgencyId", oldAgent.AgencyID);

            try
            {
                connect.Open();
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0) success = false;//did not update, concurrency issue

            }
            catch (Exception e) { throw e; }
            finally { connect.Close(); }

            return success;
        }

        //deletes an agent
        public static bool DeleteAgent(Agent agt)
        {
            bool success = true;

            SqlConnection connect = TravelExpertsDBConn.getDbConnection();
            string deleteQuery = "DELETE FROM agents WHERE AgentId = @AgentID AND AgtFirstName = @AgtFirstName " +
                        "AND AgtMiddleInitial = @AgtMiddleInitial AND AgtLastName = @AgtLastName AND " +
                        "AgtBusPhone = @AgtBusPhone AND AgtEmail = @AgtEmail AND AgtPosition = @AgtPosition AND " +
                        "AgencyId = @AgencyID";
            SqlCommand cmd = new SqlCommand(deleteQuery, connect);

            //inputs the parameters to check them
            cmd.Parameters.AddWithValue("@AgentID", agt.AgentID);
            cmd.Parameters.AddWithValue("@AgtFirstName", agt.AgtFirstName);
            cmd.Parameters.AddWithValue("@AgtMiddleInitial", agt.AgtMiddleInitial);
            cmd.Parameters.AddWithValue("@AgtLastName", agt.AgtLastName);
            cmd.Parameters.AddWithValue("@AgtBusPhone", agt.AgtBusPhone);
            cmd.Parameters.AddWithValue("@AgtEmail", agt.AgtEmail);
            cmd.Parameters.AddWithValue("@AgtPosition", agt.AgtPosition);
            cmd.Parameters.AddWithValue("@AgencyID", agt.AgencyID);

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
