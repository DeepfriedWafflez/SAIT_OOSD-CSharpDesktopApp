using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsClasses
{
    /// <summary>
    /// ProductSupplier class object for the TravelExperts database 
    /// </summary>
    /// Author: Stuart Peters
    /// Date: March 2019
    public class ProductSupplier
    {

        //properties
        public int ProductSupplierId { get; set; }

        public int ProductId { get; set; }

        public int SupplierId { get; set; }

        //constructor
        public ProductSupplier() { }

        public ProductSupplier(int i, int p, int s)
        {
            ProductSupplierId = i;
            ProductId = p;
            SupplierId = s;

        }

        //methods
        public override string ToString()
        {
            return "ProductSupplier ID: " + ProductSupplierId + "\n" +
                   "Product ID: " + ProductId + "\n" +
                   "Product ID: " + SupplierId;
        }

    }
}
