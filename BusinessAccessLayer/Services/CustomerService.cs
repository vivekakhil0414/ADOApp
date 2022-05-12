using BusinessAccessLayer.Contract;
using CommanLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Services
{
    
    public class CustomerService : ICustomer
    {
        private CustomerDbOperation dbOperation;
        public CustomerService()
        {
            dbOperation = new CustomerDbOperation();
        }

       

        public Customer CreateCustomer(Customer obj)
        {
           var result= dbOperation.CreateCustomer(obj);
            return result;
        }

        public bool DeleteCustomer(int id)
        {
          var result= dbOperation.DeleteCustomer(id);
            return result;
        }

        public Customer EditCustomer( Customer customer)
        {
            var result = dbOperation.EditCustomer(customer);
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            var result = dbOperation.GetCustomerById(id);
            return result;
        }

        public List<Customer> GetCustomers()
        {
            return dbOperation.GetCustomer();
        }
    }
}
