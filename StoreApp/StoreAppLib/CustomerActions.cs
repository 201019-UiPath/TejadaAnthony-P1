using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class CustomerActions : ICustomerActions
    {
        private StoreAppContext context;
        private ICustomerRepoActions repoActions;

        public CustomerActions(StoreAppContext context, ICustomerRepoActions repo)
        {
            this.repoActions = repo;
            this.context = context;

        }

        public List<Customer> GetAllCustomers() {
            return repoActions.GetAllCustomers();
        }

        public bool CustomerExists(string email, string password)
        {

            return repoActions.CheckIfCustomerExists(email, password);

        }

        public void AddCustomer(Customer newCustomer)
        {

            repoActions.AddCustomerIntoTable(newCustomer);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return repoActions.GetCustomerByEmail(email);
        }


    }
}