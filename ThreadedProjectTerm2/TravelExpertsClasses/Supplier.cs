using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsClasses
{
    /**
     * Threaded project 2 - Team 1
     * Purpose: Supplier object to store supplier data from database
     * Made by: Brent Ward
     * Date: March 12th 2019
     * **/
    public class Supplier
    {
        public Supplier() { }

        //allows values to be set/grabbed
        public int SupID { get; set; }
        public string SupName { get; set; }
    }
}
