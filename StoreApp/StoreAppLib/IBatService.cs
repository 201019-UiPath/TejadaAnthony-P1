using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IBatService
    {
        Bat GetBatById(int id);
        Bat GetBatByName(string product);
        List<Bat> GetAllBats();
        void AddBat(Bat bat);
        void DeleteBat(Bat bat);
        void UpdateBat(Bat bat);

    }
}