using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Models;

namespace BusinessAccessLayer.Contract
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
        Customer CreateCustomer(Customer obj);
        bool DeleteCustomer(int id);
        Customer GetCustomerById(int id);
        Customer EditCustomer( Customer customer);
    }
}
