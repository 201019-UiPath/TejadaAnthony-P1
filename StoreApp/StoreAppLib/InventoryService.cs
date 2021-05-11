using System.Collections.Generic;
using System.Data.SqlTypes;
using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;
namespace StoreAppLib
{
    public class InventoryService : IInventoryService
    {
        private StoreAppContext context;
        private IInventoryRepoActions repo;

        public InventoryService(StoreAppContext context, IInventoryRepoActions repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public void AddInventoryItem(Inventory inventory)
        {
            repo.AddInventoryItem(inventory);
        }

        public void DeleteInventoryItem(Inventory inventory)
        {
            repo.DeleteInventoryItem(inventory);
        }

        public List<Inventory> GetAllInventoryItemsById(int id)
        {
            return repo.GetAllInventoryItemsById(id);
        }

        public List<Inventory> GetAllInventoryItemsByLocationId(int id)
        {
            return repo.GetAllInventoryItemsByLocationId(id);
        }

        public Inventory GetInventoryItemById(int id)
        {
            return repo.GetInventoryItemById(id);
        }

        public Inventory GetInventoryItemByLocationId(int id)
        {
            return repo.GetInventoryItemByLocationId(id);
        }

        public Inventory GetItemByLocationIdBatId(int locationId, int batId)
        {
            return repo.GetItemByLocationIdBatId(locationId, batId);
        }

        public void UpdateInventoryItem(Inventory inventory)
        {
            repo.UpdateInventoryItem(inventory);
        }
    }
}