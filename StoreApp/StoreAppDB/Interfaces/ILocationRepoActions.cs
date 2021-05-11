using StoreAppDB.Models;
using System.Collections.Generic;
namespace StoreAppDB.Interfaces
{
    public interface ILocationRepoActions
    {

        void AddLocation(Location location);
        void UpdateLocation(Location location);
        Location GetLocationById(int id);
        Location GetLocationByState(string state);
        List<Location> GetAllLocations();
        void DeleteLocation(Location location);
    }
}