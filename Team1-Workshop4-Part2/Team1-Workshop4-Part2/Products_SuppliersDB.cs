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

        public static List<Supplier> GetProductSuppliers(int id)  // returns a list of suppliers for a given product ID
        {
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


        // DM: This method gets a ProductSupplierId by the selected product and supplier

        public static int GetProductSupplierId(int ProductId, int SupplierId)
        {
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

    } // end class
}
