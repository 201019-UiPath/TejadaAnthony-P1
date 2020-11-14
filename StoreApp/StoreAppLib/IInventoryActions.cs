using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IInventoryActions
    {
        Inventory GetInventoryById(int id);
        List<Inventory> GetInventoryByLocationId(int id);
        void UpdateInventory(Inventory inventory);
    }
}