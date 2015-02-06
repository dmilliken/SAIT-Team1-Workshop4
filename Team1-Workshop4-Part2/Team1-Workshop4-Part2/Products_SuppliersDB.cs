using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team1_Workshop4_Part2
{
    public static class Products_SuppliersDB  // Mark 
    {

        // Methods for adding and updating the Products_Suppliers table
        // ---------------------------------------------
        // ---------------------------------------------
  
        public static Supplier GetProductSupplier(int id)
        {   
            // get selected text from 
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Products_Suppliers "
                + "WHERE ProductID = @ProductID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", id);

            try
            {
                connection.Open();
                SqlDataReader supReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (supReader.Read())
                {
                    Products_Suppliers ps = new Products_Suppliers();
                    ps.ProductSupplierId = (int)supReader["ProductSupplierId"];
                    ps.ProductId = (int)supReader["ProductId"];
                    ps.SupplierId = (int)supReader["SupplierID"];

                    //supplier id goes to find sup. 

                Supplier q = SupplierDB.GetSupplier(ps.SupplierId); 

                    return q;
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

        public static Supplier GetSupplierProduct(int id)
        {
            // get selected text from 
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Products_Suppliers "
                + "WHERE SupplierID = @SupplierID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@SupplierID", id);

            try
            {
                connection.Open();
                SqlDataReader supReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (supReader.Read())
                {
                    Products_Suppliers ps = new Products_Suppliers();
                    ps.ProductSupplierId = (int)supReader["ProductSupplierId"];
                    ps.ProductId = (int)supReader["ProductId"];
                    ps.SupplierId = (int)supReader["SupplierID"];

                    //supplier id goes to find sup. 

                    Supplier q = SupplierDB.GetSupplier(ps.SupplierId);

                    return q;
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

        public static List<Product> GetProductsBySupplier(int SupplierId)  // returns a list of products for a given supplier ID
        {
            // create list of suppliers
            // example query: SELECT Products_Suppliers.ProductId, SupplierId,ProdName FROM Products_Suppliers INNER JOIN Products on Products_Suppliers.ProductId = Products.ProductId WHERE SupplierId = 3600
            List<Product> supplierProducts = new List<Product>();

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT Products_Suppliers.ProductId, SupplierId,ProdName "
                + "FROM Products_Suppliers "
                + "INNER JOIN Products on Products_Suppliers.ProductId = Products.ProductId "
                + "WHERE SupplierId = @SupplierId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@SupplierId", SupplierId);

            try
            {
                connection.Open();
                SqlDataReader supReader =
                    selectCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                while (supReader.Read())
                {
                    Product p = new Product();
                    // ps.ProductSupplierId = (int)supReader["ProductSupplierId"];
                    p.ProductId = (int)supReader["ProductId"];
                    //ps.SupplierId = (int)supReader["SupplierID"];
                    p.ProdName = (string)supReader["ProdName"];

                    supplierProducts.Add(p);
                    
                }
                return supplierProducts;
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

        // Darcie 
        public static int GetProductSupplierId(int ProductId, int SupplierId)
        {
            // This method gets a ProductSupplierId by the selected product and supplier
            // example select statement SELECT * from Products_Suppliers WHERE SupplierId = 3600 AND ProductId = 8 returns 46
            int ProductSupplierId = 0;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT ProductSupplierId "
                + "FROM Products_Suppliers "
                + "WHERE ProductID = @ProductID AND SupplierId = @SupplierId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", ProductId);
            selectCommand.Parameters.AddWithValue("@SupplierID", SupplierId);


            try
            {
                connection.Open();
                SqlDataReader Reader =
                    selectCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                if (Reader.Read())
                {
                    ProductSupplierId = (int)Reader["ProductSupplierId"];
                }
                return ProductSupplierId;
            }

            catch (SqlException ex)
            {

                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }//end method

        public static List<Supplier> GetProductSuppliers(int id)  
        {
            // returns a list of suppliers for a given product ID
            // create list of suppliers
            List<Supplier> suppliers = new List<Supplier>();

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Products_Suppliers "
                + "WHERE ProductID = @ProductID";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", id);

            try
            {
                connection.Open();
                SqlDataReader supReader =
                    selectCommand.ExecuteReader(CommandBehavior.SequentialAccess);
                while (supReader.Read())
                {
                    Products_Suppliers ps = new Products_Suppliers();
                    ps.ProductSupplierId = (int)supReader["ProductSupplierId"];
                    ps.ProductId = (int)supReader["ProductId"];
                    ps.SupplierId = (int)supReader["SupplierID"];

                    //supplier id goes to find sup. 

                    Supplier q = SupplierDB.GetSupplier(ps.SupplierId);
                    suppliers.Add(q);

                }
                return suppliers;
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

        public static bool RemoveProductFromSupplier(int ProductId, int SupplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products_Suppliers " +
                "WHERE ProductId = @ProductId " +
                "AND SupplierId = @SupplierId";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ProductId", ProductId);
            deleteCommand.Parameters.AddWithValue(
            "@SupplierId", SupplierId);
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
        }//end method

        public static bool AddProductToSupplier(int ProductId, int SupplierId)
        { 
            //this method adds a product to a selected supplier

            // example : INSERT INTO Products_Suppliers VALUES (2,1040)

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT INTO Products_Suppliers " +
                "VALUES (@ProductId, @SupplierId)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductId", ProductId);
            insertCommand.Parameters.AddWithValue(
                "@SupplierId", SupplierId);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                //string selectStatement =
                //    "SELECT IDENT_CURRENT('Products') FROM Products";
                //SqlCommand selectCommand =
                 //   new SqlCommand(selectStatement, connection);
                //int ProductID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return true;
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
