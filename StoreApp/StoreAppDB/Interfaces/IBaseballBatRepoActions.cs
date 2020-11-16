using StoreAppDB.Models;
using System.Collections.Generic;
namespace StoreAppDB.Interfaces
{
    public interface IBaseballBatRepoActions
    {
        List<BaseballBat> GetAllBaseballBats();

        BaseballBat GetBaseballBatById(int id);
        void AddBaseballBatIntoTableAsync(BaseballBat baseballbat);

        void UpdateBaseballBat(BaseballBat bat);

        void DeleteBaseballBat(BaseballBat bat);
    }
}