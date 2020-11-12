using StoreAppDB.Models;
using System.Collections.Generic;

namespace StoreAppLib
{
    public interface IBaseballBatActions
    {
        BaseballBat GetBaseballBatById(int id);
        List<BaseballBat> GetAllBaseballBats();
        void AddBaseballBat(BaseballBat newBaseballBat);

        void UpdateBaseballBat(BaseballBat bat);

        void DeleteBaseballBat(BaseballBat bat);
    }
}