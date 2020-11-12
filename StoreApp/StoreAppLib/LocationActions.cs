using System.Data.SqlTypes;
using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
using System.Collections.Generic;

namespace StoreAppLib
{
    public class LocationActions : ILocationActions
    {
        private StoreAppContext context;
        private ILocationRepoActions locationRepo;

        public LocationActions(StoreAppContext context, ILocationRepoActions locationRepo)
        {
            this.context = context;
            this.locationRepo = locationRepo;
        }

        public Location GetLocationById(int locationId)
        {

            return locationRepo.GetLocationById(locationId);
        }

        public List<Location> GetAllLocations()
        {

            return locationRepo.GetAllLocations();
        }
    }
}