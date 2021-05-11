using StoreAppDB.Models;
using System.Collections.Generic;
namespace StoreAppDB.Interfaces
{
    public interface IBatRepoActions
    {
        List<Bat> GetAllBats();
        Bat GetBatById(int id);
        Bat GetBatByName(string name);
        void AddBat(Bat bat);
        void UpdateBat(Bat bat);
        void DeleteBat(Bat bat);
    }
}