using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Workshop4_Part2
{
    //create package object using only package table
    public class Packages
    {
        public Packages() { }

        public int PackageID { get; set;}

        public string PkgName { get; set; }

        public string PkgStartDate { get; set; }
        //public DateTime PkgStartDate { get; set; }

        //public string PkgEndDate { get; set; }
        public DateTime PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public double PkgBasePrice { get; set; }

        public double PkgAgencyCommission { get; set; }

    }
    //create a custom package object with the booking date attached
    public class PackagesWBooking
    {
        public PackagesWBooking() { }

        public int PackageID { get; set; }

        public string PkgName { get; set; }

        public string PkgStartDate { get; set; }

        public string PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public double PkgBasePrice { get; set; }

        public double PkgAgencyCommission { get; set; }

        public string BookingDate { get; set; }

    }
}
