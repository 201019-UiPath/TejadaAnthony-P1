using System.Data.SqlTypes;
using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class LocationService : ILocationService
    {
        private StoreAppContext context;
        private ILocationRepoActions repo;

        public LocationService(StoreAppContext context, ILocationRepoActions repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }

        public void DeleteLocation(Location location)
        {
            repo.DeleteLocation(location);
        }

        public List<Location> GetAllLocations()
        {
            return repo.GetAllLocations();
        }

        public Location GetLocationById(int id)
        {
            return repo.GetLocationById(id);
        }

        public Location GetLocationByState(string state)
        {
            return repo.GetLocationByState(state);
        }

        public void UpdateLocation(Location location)
        {
             repo.UpdateLocation(location);
        }
    }
}