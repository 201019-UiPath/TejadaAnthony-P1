using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class ManagerActions : IManagerActions
    {
        private StoreAppContext context;
        private IManagerRepoActions repoActions;

        public ManagerActions(StoreAppContext context, IManagerRepoActions repo)
        {
            this.repoActions = repo;
            this.context = context;

        }

        public void AddManager(Manager manager) {
            repoActions.AddManager(manager);
        }

        public List<Manager> GetAllManagers()
        {

            return repoActions.GetAllManagers();
        }

        public bool ManagerExists(string email, string password)
        {

            return repoActions.CheckIfManagerExists(email, password);

        }
    }
}