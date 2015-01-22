using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

//Created By Mark Davidson
//Group #1
//CPRG 214
//Last Edited  Jan 21 2015


namespace Team1_Workshop4_Part2
{
    [DataObject(true)]
    public static class CustomerDB
    {

        //Create full list of all Customers
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Customer> GetAllCustomers()
        {
            List<Customer>  customers = new List<Customer>(); // empty list
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT CustomerID, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, " +
                "CustHomePhone, CustBusPhone, CustEmail, AgentID FROM Customers ";
                
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            
            try
            {
                connection.Open();
                SqlDataReader custReader = selectCommand.ExecuteReader();
                while(custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.CustFirstName = (string)custReader["CustFirstName"];
                    customer.CustLastName = (string)custReader["CustLastName"];
                    customer.CustAddress = (string)custReader["CustAddress"];
                    customer.CustCity = (string)custReader["CustCity"];
                    customer.CustProv = (string)custReader["CustProv"];
                    customer.CustPostal = (string)custReader["CustPostal"];
                    customer.CustCountry = (string)custReader["CustCountry"];
                    customer.CustHomePhone = (string)custReader["CustHomePhone"];
                    customer.CustBusPhone = (string)custReader["CustBusPhone"];
                    customer.CustEmail = (string)custReader["CustEmail"];
                    customer.AgentId = (int)custReader["AgentID"];
                    customers.Add(customer);
                }
                custReader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return customers;
        }


        //Find single customer by ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Customer GetCustomerByID(int customerID)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                "SELECT CustomerID, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, " +
                "CustHomePhone, CustBusPhone, CustEmail, AgentID FROM Customers ";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                SqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.CustFirstName = (string)custReader["CustFirstName"];
                    customer.CustLastName = (string)custReader["CustLastName"];
                    customer.CustAddress = (string)custReader["CustAddress"];
                    customer.CustCity = (string)custReader["CustCity"];
                    customer.CustProv = (string)custReader["CustProv"];
                    customer.CustPostal = (string)custReader["CustPostal"];
                    customer.CustCountry = (string)custReader["CustCountry"];
                    customer.CustHomePhone = (string)custReader["CustHomePhone"];
                    customer.CustBusPhone = (string)custReader["CustBusPhone"];
                    customer.CustEmail = (string)custReader["CustEmail"];
                    customer.AgentId = (int)custReader["AgentID"];
                    
                    return customer;
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


        //Add Customer
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddCustomer(Customer customer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(CustFirstName,CustLastName, CustAddress, CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone) " +
                "VALUES (@CustFirstName, @CustLastName, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry, @CustHomePhone, @CustBusPhone)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@CustFirstName", customer.CustFirstName);
            insertCommand.Parameters.AddWithValue(
                "@CustLastName", customer.CustLastName);
            insertCommand.Parameters.AddWithValue(
                "@CustAddress", customer.CustAddress);
            insertCommand.Parameters.AddWithValue(
                "@CustCity", customer.CustCity);
            insertCommand.Parameters.AddWithValue(
                "@CustProv", customer.CustProv);
            insertCommand.Parameters.AddWithValue(
                "@CustPostal", customer.CustPostal);
            insertCommand.Parameters.AddWithValue(
                "@CustCountry", customer.CustCountry);
            insertCommand.Parameters.AddWithValue(
                "@CustHomePhone", customer.CustHomePhone);
            insertCommand.Parameters.AddWithValue(
                "@CustBusPhone", customer.CustBusPhone);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Customers') FROM Customers";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
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


        //Update customer
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool UpdateCustomer(Customer original_,
            Customer newCustomer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@CustFirstName", original_.CustFirstName);
            updateCommand.Parameters.AddWithValue(
                "@CustLastName", original_.CustLastName);
            updateCommand.Parameters.AddWithValue(
                "@CustAddress", original_.CustAddress);
            updateCommand.Parameters.AddWithValue(
                "@CustCity", original_.CustCity);
            updateCommand.Parameters.AddWithValue(
                "@CustProv", original_.CustProv);
            updateCommand.Parameters.AddWithValue(
                "@CustPostal", original_.CustPostal);
            updateCommand.Parameters.AddWithValue(
                "@CustCountry", original_.CustCountry);
            updateCommand.Parameters.AddWithValue(
                "@CustHomePhone", original_.CustHomePhone);
            updateCommand.Parameters.AddWithValue(
                "@CustBusPhone", original_.CustBusPhone);
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

        //Delete customer
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static bool DeleteCustomer(Customer customer)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustFirstName = @CustFirstName " +
                "CustLastName = @CustLastName " +
                "AND CustAddress = @CustAddress " +
                "AND CityCity = @CityCity " +
                "AND CustProv = @CustProv " + 
                "AND CustPostal = @CustPostal"+
                "AND CustCountry = @CustCountry " +
                "AND CustHomePhone = @CustHomePhone " +
                "AND CustBusPhone = @CustBusPhone " +
                "AND CustEmail = @CustEmail " +
                "AND AgentId = @AgentId";

            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@CustFirstName", customer.CustFirstName);
            deleteCommand.Parameters.AddWithValue(
                "@CustLastName", customer.CustLastName);
            deleteCommand.Parameters.AddWithValue(
                "@CustAddress", customer.CustAddress);
            deleteCommand.Parameters.AddWithValue(
                "@CustCity", customer.CustCity);
            deleteCommand.Parameters.AddWithValue(
                "@CustProv", customer.CustProv);
            deleteCommand.Parameters.AddWithValue(
                "@CustPostal", customer.CustPostal);
            deleteCommand.Parameters.AddWithValue(
                "@CustCountry", customer.CustCountry);
            deleteCommand.Parameters.AddWithValue(
                "@CustHomePhone", customer.CustHomePhone);
            deleteCommand.Parameters.AddWithValue(
                "@CustBusPhone", customer.CustBusPhone);
            deleteCommand.Parameters.AddWithValue(
                "@CustEmail", customer.CustEmail);
            deleteCommand.Parameters.AddWithValue(
                 "@AgentId", customer.AgentId);

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
    }
}
