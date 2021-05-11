using StoreAppDB.Models;
using System.Collections.Generic;


namespace StoreAppDB.Interfaces
{
    public interface IInventoryRepoActions
    {
        void AddInventoryItem(Inventory inventoryItem);
        void UpdateInventoryItem(Inventory inventoryItem);
        Inventory GetInventoryItemById(int id);
        List<Inventory> GetAllInventoryItemsById(int id);
        Inventory GetInventoryItemByLocationId(int id);
        List<Inventory> GetAllInventoryItemsByLocationId(int id);
        void DeleteInventoryItem(Inventory inventoryItem);
        Inventory GetItemByLocationIdBatId(int locationId, int batId);
    }
}