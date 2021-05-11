using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IInventoryService
    {
        void AddInventoryItem(Inventory inventory);
        void DeleteInventoryItem(Inventory inventory);
        List<Inventory> GetAllInventoryItemsById(int id);
        List<Inventory> GetAllInventoryItemsByLocationId(int id);
        Inventory GetInventoryItemById(int id);
        Inventory GetInventoryItemByLocationId(int id);
        Inventory GetItemByLocationIdBatId(int locationId, int batId);
        void UpdateInventoryItem(Inventory inventory);
    }
}