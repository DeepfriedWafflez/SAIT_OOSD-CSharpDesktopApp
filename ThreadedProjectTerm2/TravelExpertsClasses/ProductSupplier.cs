using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsClasses
{
    public class ProductSupplier
    {

        //properties
        public int ProductSupplierID { get; set; }

        public int ProductID { get; set; }

        public int SupplierID { get; set; }

        //constructor
        public ProductSupplier() { }

        public ProductSupplier(int i, int p, int s)
        {
            ProductSupplierID = i;
            ProductID = p;
            SupplierID = s;

        }

        //methods
        public override string ToString()
        {
            return "ProductSupplier ID: " + ProductSupplierID + "\n" +
                   "Product ID: " + ProductID + "\n" +
                   "Product ID: " + SupplierID;
        }

    }
}
