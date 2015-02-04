using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Workshop4_Part2 
{   
    // Brodie Modified Feb 4 2015
    //[DataObject(true)]
    public class PackagesDB
    {

        public static int AddPackages(Packages package)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "Insert package " +
                                     "(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                     "VALUES (@pkgname, @pkgstartdate, @pkgenddate, @pkgDesc, @pkgbaseprice, @pkgagencycommission)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@pkgname", package.PkgName);
            insertCommand.Parameters.AddWithValue("@pkgstartdate", package.PkgStartDate);
            insertCommand.Parameters.AddWithValue("@pkgenddate", package.PkgEndDate);
            insertCommand.Parameters.AddWithValue("@pkgDesc", package.PkgDesc);
            insertCommand.Parameters.AddWithValue("@pkgbaseprice", package.PkgBasePrice);
            insertCommand.Parameters.AddWithValue("@pkgagencycommission", package.PkgAgencyCommission);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                //based on the assumption that the packages with auto increment when created
                string selectStatement = "SELECT IDENT_CURRENT('Packages') FROM Packages";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int packageId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return packageId;


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public static Packages GetPackage(int PackageId)
        {
        //DM: this method gets package object info by package ID.
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Packages "
                + "WHERE PackageId = @PackageId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PackageId", PackageId);

            try
            {
                connection.Open();
                SqlDataReader Reader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (Reader.Read())
                {
                    Packages package = new Packages();
                    package.PackageID = (int)Reader["PackageId"];
                    package.PkgName = Reader["PkgName"].ToString();
                    //package.PkgStartDate = Convert.ToDateTime(Reader["PkgStartDate"]); //could not convert to Datetime?
                    package.PkgStartDate = Convert.ToDateTime(Reader["PkgStartDate"]); //could not convert to Datetime?
                    package.PkgEndDate = Convert.ToDateTime(Reader["PkgEndDate"]);
                    package.PkgDesc = Reader["PkgDesc"].ToString();
                    package.PkgBasePrice = Convert.ToDouble(Reader["PkgBasePrice"]);
                    package.PkgAgencyCommission = Convert.ToDouble(Reader["PkgAgencyCommission"]);

                    return package;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } //end method

        //get packages with the bookingdate using the booking id
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public List<PackagesWBooking> GetPackagesWithBookingDate(int bookingId) 
        {
            //create a list using the packages with dates objects
            List<PackagesWBooking> packagesWBookings = new List<PackagesWBooking>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //select statement with inner join to get the booking date
            string selectStatement = "SELECT PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission, BookingDate " +
                                     "FROM Packages p INNER JOIN Bookings b on b.PackageId = p.PackageId Where BookingId = @bookingId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@bookingId", bookingId);


            try
            {
                connection.Open();

                //SqlDataReader reader = new SqlDataReader();
                //selectCommand.ExecuteReader();

                SqlDataReader reader = selectCommand.ExecuteReader();
                
                //while reader is executing 
                while (reader.Read())
                {
                    //create a new package with booking object 
                    PackagesWBooking p = new PackagesWBooking();
                    //fill the object values with using the reader and converting to proper data types
                    p.PkgName = reader["PkgName"].ToString();
                    p.PkgStartDate = reader["PkgStartDate"].ToString();
                    p.PkgEndDate = reader["PkgEndDate"].ToString();
                    p.PkgDesc = reader["PkgDesc"].ToString();
                    p.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"]);
                    p.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"]);
                    p.BookingDate= reader["BookingDate"].ToString();
                    //add new object to the list created
                    packagesWBookings.Add(p);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            //return the list 
            return packagesWBookings;

        }
        //variation of the get packages class that returns just the packages in the database and only using the columns of the table
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Packages> GetAllPackages()
        {
            List<Packages> packages = new List<Packages>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT PackageId,PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission " +
                                     "FROM Packages";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            
            


            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Packages p = new Packages();
                    p.PackageID = Convert.ToInt32(reader["PackageId"]);
                    p.PkgName = reader["PkgName"].ToString();
                    // p.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"]);
                    p.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"]);
                    p.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"]);
                    p.PkgDesc = reader["PkgDesc"].ToString();
                    p.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"]);
                    p.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"]);
                    
                    packages.Add(p);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return packages;

        }
        //third variation where the customer Id is used to obtain the packages
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public List<PackagesWBooking> GetPackagesFromCustomers(int customerId)
        {
            List<PackagesWBooking> packagesWBooking = new List<PackagesWBooking>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                                     "FROM Packages p INNER JOIN Bookings b on b.PackageId = p.PackageId "+
                                                     "INNER JOIN Customers c on c.CustomerId = b.CustomerId "+
                                                     "WHERE CustomerId = @customerId";
                                      
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@customerId", customerId);


            try
            {
                connection.Open();

                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    PackagesWBooking p = new PackagesWBooking();
                    p.PkgName = reader["PkgName"].ToString();
                    p.PkgStartDate = reader["PkgStartDate"].ToString();
                    p.PkgEndDate = reader["PkgEndDate"].ToString();
                    p.PkgDesc = reader["PkgDesc"].ToString();
                    p.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"]);
                    p.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"]);
                    p.BookingDate = reader["BookingDate"].ToString();
                    packagesWBooking.Add(p);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return packagesWBooking;

        } // end method

        // Darcie: This Method edits a package
        // PackageID is autogenerated and hidden from the user. 
        public static bool EditPackage(Packages oldPackage, Packages newPackage)
        {
            
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Packages SET " +
                "PkgName = @NewPkgName, " +
                "PkgStartDate = @NewPkgStartDate, " +
                "PkgEndDate = @NewPkgEndDate, " +
                "PkgDesc = @NewPkgDesc, " +
                "PkgBasePrice = @NewPkgBasePrice, " +
                "PkgAgencyCommission = @NewPkgAgencyCommission " +
                "WHERE PkgName = @OldPkgName " +
                "AND PkgStartDate = @OldPkgStartDate " + 
                "AND PkgEndDate = @OldPkgEndDate " + 
                "AND PkgDesc = @OldPkgDesc " + 
                "AND PkgBasePrice = @OldPkgBasePrice " +
                "AND PkgAgencyCommission = @OldPkgAgencyCommission";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            
            //paramaters for the new package values
            updateCommand.Parameters.AddWithValue(
                "@NewPkgName", newPackage.PkgName);
            updateCommand.Parameters.AddWithValue(
                "@NewPkgStartDate", newPackage.PkgStartDate);
            updateCommand.Parameters.AddWithValue(
                "@NewPkgEndDate", newPackage.PkgEndDate);
            updateCommand.Parameters.AddWithValue(
                "@NewPkgDesc", newPackage.PkgDesc);
            updateCommand.Parameters.AddWithValue(
                "@NewPkgBasePrice", newPackage.PkgBasePrice);
            updateCommand.Parameters.AddWithValue(
                "@NewPkgAgencyCommission", newPackage.PkgAgencyCommission);

            // parameters for the old/original values
            updateCommand.Parameters.AddWithValue(
                "@OldPkgName", oldPackage.PkgName);
            updateCommand.Parameters.AddWithValue(
                "@OldPkgStartDate", oldPackage.PkgStartDate);
            updateCommand.Parameters.AddWithValue(
                "@OldPkgEndDate", oldPackage.PkgEndDate);
            updateCommand.Parameters.AddWithValue(
                "@OldPkgDesc", oldPackage.PkgDesc);
            updateCommand.Parameters.AddWithValue(
                "@OldPkgBasePrice", oldPackage.PkgBasePrice);
            updateCommand.Parameters.AddWithValue(
                "@OldPkgAgencyCommission", oldPackage.PkgAgencyCommission);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        } // end method 


        // Darcie: This method adds a new package

        // method for adding a new row of product
        public static int AddPackage(Packages package)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT INTO Packages " +
                "(Pkgname,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission) " +
                "VALUES (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@PkgName", package.PkgName);
            insertCommand.Parameters.AddWithValue(
                "@PkgStartDate", package.PkgStartDate);
            insertCommand.Parameters.AddWithValue(
                "@PkgEndDate", package.PkgEndDate);
            insertCommand.Parameters.AddWithValue(
                "@PkgDesc", package.PkgDesc);
            insertCommand.Parameters.AddWithValue(
                "@PkgBasePrice", package.PkgBasePrice);
            insertCommand.Parameters.AddWithValue(
                "@PkgAgencyCommission", package.PkgAgencyCommission);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Packages') FROM Packages";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int PackageId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return PackageId;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
    } // end class
        
}
