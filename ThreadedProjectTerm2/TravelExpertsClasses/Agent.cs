using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsClasses
{
    /**
     * Threaded project 2 - Team 1
     * Purpose: Agent object to store agent data from database
     * Made by: Brent Ward
     * Date: March 12th 2019
     * **/

    public class Agent
    {
        public Agent() { }

        //allows values to be set/grabbed
        public int AgentID { get; set; }
        public string AgtFirstName { get; set; }
        public string AgtLastName { get; set; }
        public string AgtMiddleInitial { get; set; }
        public string AgtBusPhone { get; set; }
        public string AgtEmail { get; set; }
        public string AgtPosition { get; set; }
        public int AgencyID { get; set; }
    }
}
