using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsClasses
{
    public class Bookings
    {
        public int PackageId { get; set; }
        public string BookingNo { get; set; }
        public int CustomerId { get; set; }
        public string TripTypeId { get; set; }
    }
}
