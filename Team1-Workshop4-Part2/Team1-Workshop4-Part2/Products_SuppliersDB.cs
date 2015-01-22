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
        }    
    }
}
