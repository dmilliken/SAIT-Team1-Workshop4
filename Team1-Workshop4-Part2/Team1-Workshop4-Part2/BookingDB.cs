using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CJ: DB layer class for Booking table
namespace Team1_Workshop4_Part2
{
    public static class BookingDB
    {
        //method for fetching product info
        public static Booking GetBooking(int BookingId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT BookingId, BookingDate, BookingNo, TravelerCount, CustomerId, TripTypeId, PackageId "
                + "FROM Bookings "
                + "WHERE BookingId = @BookingId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@BookingId", BookingId);

            try
            {
                connection.Open();
                SqlDataReader bookReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (bookReader.Read())
                {
                    Booking booking = new Booking();
                    booking.BookingId = (int)bookReader["BookingId"];
                    booking.BookingDate = bookReader["BookingDate"].ToString();
                    booking.BookingNo = bookReader["BookingNo"].ToString();
                    booking.TravelerCount = (int)bookReader["TravelerCount"];
                    booking.CustomerId = (int)bookReader["CustomerId"];
                    booking.TripTypeId = bookReader["TripTypeId"].ToString();
                    booking.PackageId = (int)bookReader["PackageId"];
                    return booking;
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
        }

        // get all list that can be used for combobox
        public static List<Booking> GetAllBookings()
        {
            // get all products for the combo box 
            List<Booking> bookingcodes = new List<Booking>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT BookingId FROM Bookings";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Booking b = new Booking();
                    b.BookingId = Convert.ToInt32(reader["BookingId"]);
                    bookingcodes.Add(b);
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
            return bookingcodes;
        }
    }
}
