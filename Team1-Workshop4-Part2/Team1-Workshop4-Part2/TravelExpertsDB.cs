using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Workshop4_Part2
{
    class TravelExpertsDB
    {
        // DM: This class contains the connection to the Travel Experts DB. We have included a few ways of connecting here based on some unique difficulties we each encountered.
        public static SqlConnection GetConnection()
        {
            //string connectionString = "Initial Catalog=uniquenamehere;Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\TravelExperts_Data.mdf;Integrated Security=True;User Instance=True";
           string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            //string connectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\TravelExperts_Data.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        } // end method
    } // end class
}
