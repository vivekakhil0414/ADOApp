using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
   public class CustomerDbOperation
    {
        private DbConnect dbConnect;
        public CustomerDbOperation()
        {
            dbConnect = new DbConnect();
        }

        public List<Customer> GetCustomer()
        {
            SqlCommand command = new SqlCommand("Sp_Customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT");
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                Customer obj = new Customer();
                obj.Id = (int)reader["id"];
                obj.FirstName = reader["FirstName"].ToString();
                obj.LastName = reader["LastName"].ToString();
                obj.Email = reader["Email"].ToString();
                obj.Mobile = reader["Mobile"].ToString();
                obj.Address = reader["Address"].ToString();
                customers.Add(obj);

            }
            dbConnect.connection.Close();
            return customers;
        }

        public Customer CreateCustomer(Customer customer)
        {

            SqlCommand command = new SqlCommand("Sp_Customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "CREATE");
            command.Parameters.AddWithValue("@fistname", customer.FirstName);
            command.Parameters.AddWithValue("@lastname", customer.LastName);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@mobile", customer.Mobile);
            command.Parameters.AddWithValue("@address", customer.Address);
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            var result = (int)command.ExecuteScalar();
            dbConnect.connection.Close();
            if (result == 1)
            {
                return customer;
            }
            else
            {
                return null;
            }

        }
        public Customer GetCustomerById(int id)
        {

            SqlCommand command = new SqlCommand("Sp_Customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT_SINGLE");
            command.Parameters.AddWithValue("@id",id);
           
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            Customer obj = new Customer();
            obj.Id = (int)dr["id"];
            obj.FirstName = dr["FirstName"].ToString();
            obj.LastName = dr["LastName"].ToString();
            obj.Email = dr["Email"].ToString();
            obj.Mobile = dr["Mobile"].ToString();
            obj.Address = dr["Address"].ToString();
            dbConnect.connection.Close();
            return obj;
        }
        public bool DeleteCustomer(int id)
        {

            SqlCommand command = new SqlCommand("Sp_Customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "DELETE");
            command.Parameters.AddWithValue("@id", id);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            int i = (int)command.ExecuteScalar();
           
            dbConnect.connection.Close();
            if (i == 1)
                return true;
            else
                return false;
        }
        public Customer EditCustomer(Customer customer)
        {
            SqlCommand command = new SqlCommand("Sp_Customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "UPDATE");
            command.Parameters.AddWithValue("@id",customer.Id);
            command.Parameters.AddWithValue("@fistname", customer.FirstName);
            command.Parameters.AddWithValue("@lastname", customer.LastName);
            command.Parameters.AddWithValue("@email", customer.Email);
            command.Parameters.AddWithValue("@mobile", customer.Mobile);
            command.Parameters.AddWithValue("@address", customer.Address);
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            var result =(int)command.ExecuteScalar();
            dbConnect.connection.Close();
            if (result == 1)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
    
    }
}
