using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface ICustomerActions
    {
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer newCustomer);
        bool CustomerExists(string email, string password);
        Customer GetCustomerByEmail(string email);
    }
}