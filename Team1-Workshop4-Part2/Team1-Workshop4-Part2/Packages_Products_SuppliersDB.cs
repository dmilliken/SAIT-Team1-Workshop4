using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Workshop4_Part2
{
    class Packages_Products_SuppliersDB
    {

        // DM: This class contains methods to deal with the Packages_Products_Suppliers table in the Travel Experts database
        // these methods will be used for the "add product" functionality of workshop 4

        // Get a list of all products in a given package
        public static List<Product> GetProductsByPackageID(int PackageId)
        {
            // Make an empty list, connect to DB, get data

            List<Product> packageproducts = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT Products_Suppliers.ProductId,ProdName " +
                "FROM Packages INNER JOIN Packages_Products_Suppliers ON Packages.PackageId = Packages_Products_Suppliers.PackageId " +
                "INNER JOIN Products_Suppliers ON Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId " +
                "INNER JOIN Products ON Products_Suppliers.ProductId = Products.ProductId WHERE Packages.PackageId = @PackageId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PackageId", PackageId);

            try // try to connect
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(reader["ProductId"]);
                    p.ProdName = Convert.ToString(reader["ProdName"]); // might be an ambiguous column name. start here when error-checking
                    packageproducts.Add(p);
                } // end while
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return packageproducts;
        } // end method

        // This method adds a product to a package by creating an entry in the Packages_Products_Suppliers table
        public static int AddProductToPackage(int PackageId, int ProductSupplierId)
        {
            // sample statement INSERT INTO Packages_Products_Suppliers VALUES (1,46)
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT INTO Packages_Products_Suppliers VALUES (@PackageId, @ProductSupplierId)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            //create two parameters to add the values of supplier id and supplier name
            insertCommand.Parameters.AddWithValue("@PackageId", PackageId); 
            insertCommand.Parameters.AddWithValue("@ProductSupplierId", ProductSupplierId);

            try
            {

                connection.Open();
                //execture command which checks how many rows were affected
                insertCommand.ExecuteNonQuery();
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

        } //end method

    } // end class
}
