using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface ILocationActions
    {
        Location GetLocationById(int locationId);

        List<Location> GetAllLocations();
    }
}