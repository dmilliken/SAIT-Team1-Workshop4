using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CJ: middle layer class for fetching data

namespace Team1_Workshop4_Part2
{
    public class Booking
    {
        public Booking() { }

        public int BookingId { get; set; }

        public string BookingDate { get; set; }

        public string BookingNo { get; set; }

        public int TravelerCount { get; set; }

        public int CustomerId { get; set; }

        public string TripTypeId { get; set; }

        public int PackageId { get; set; }

    }
}
