using StoreAppDB.Models;
using System.Collections.Generic;
namespace StoreAppDB.Interfaces
{
    public interface ICustomerRepoActions
    {
        List<Customer> GetAllCustomers();
         bool CheckIfCustomerExists(string email, string password );
        void AddCustomerIntoTable(Customer newCustomer);

        Customer GetCustomerByEmail(string email);
    }
}