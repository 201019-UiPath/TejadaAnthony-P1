using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IManagerActions
    {
        //void AddBaseballBat(BaseballBat newBaseballBat);
        List<Manager> GetAllManagers();
        bool ManagerExists(string email, string password);

        void AddManager(Manager manager);
    }
}