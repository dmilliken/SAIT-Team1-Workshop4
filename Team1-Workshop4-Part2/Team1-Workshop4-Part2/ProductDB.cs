using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//written by Chris Joo
namespace Team1_Workshop4_Part2
{
    public static class ProductDB
    {

        // Methods for adding and updating the Product table
        // ---------------------------------------------
        // ---------------------------------------------
        //method for fetching product info
        public static Product GetProduct(int ProductId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT ProductId, ProdName "
                + "FROM Products "
                + "WHERE ProductID = @ProductID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", ProductId);

            try
            {
                connection.Open();
                SqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)prodReader["ProductId"];
                    product.ProdName = prodReader["ProdName"].ToString();
                    return product;
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

        // method for adding a new row of product
        public static int AddProduct(Product product)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProdName) " +
                "VALUES (@ProdName)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProdName", product.ProdName);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int ProductID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return ProductID;
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

        // method for updating an existing row of product
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "ProdName = @NewProdName " +
                "WHERE ProdName = @OldProdName";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewProdName", newProduct.ProdName);
            updateCommand.Parameters.AddWithValue(
                "@OldProdName", oldProduct.ProdName);
            
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
        }

        // method for deleting an existing row of product
        public static bool DeleteProduct(Product product)
        {
           //check if product has dependancies then return error or delete children
 
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProdName = @ProdName";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ProdName", product.ProdName);
            try
            {
                   
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
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
        }

        // Darcie: get a list of all products for the combo box
        public static List<Product> GetAllProducts()
        {
            // get all products for the combo box 
            List<Product> productcodes = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * FROM Products";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(reader["ProductId"]);
                    p.ProdName = Convert.ToString(reader["ProdName"]);
                    productcodes.Add(p);
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
            return productcodes;

        } // end method

        // This method gets all products that are NOT in a given package
        public static List<Product> GetSelectableProducts(int PackageId)
        {
            // get all products for the combo box 
            List<Product> products = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT ProdName FROM Products EXCEPT " +
                "(SELECT ProdName FROM Packages INNER JOIN Packages_Products_Suppliers ON Packages.PackageId = Packages_Products_Suppliers.PackageId " + 
                "INNER JOIN Products_Suppliers ON Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId " + 
                "INNER JOIN Products ON Products_Suppliers.ProductId = Products.ProductId WHERE Packages.PackageId = @PackageId)";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PackageId", PackageId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(reader["ProductId"]);
                    p.ProdName = Convert.ToString(reader["ProdName"]);
                    products.Add(p);
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
            return products;

        } // end method


        public static Product GetProductByName(string ProdName) // return a product by name
        { 
            // look in the DB for a product by this name and return it's object. Select distinct to avoid duplicates.
            // example: SELECT DISTINCT * FROM Products WHERE ProdName = 'Cruise'

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT ProductId, ProdName "
                + "FROM Products "
                + "WHERE ProdName = @ProdName";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProdName", ProdName);

            try
            {
                connection.Open();
                SqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)prodReader["ProductId"];
                    product.ProdName = prodReader["ProdName"].ToString();
                    return product;
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

    } // end class
}
