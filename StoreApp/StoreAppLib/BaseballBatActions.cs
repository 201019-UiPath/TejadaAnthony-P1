using Microsoft.CSharp.RuntimeBinder;
using System.Threading;
using System.Diagnostics;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data.SqlTypes;
using StoreAppDB.Models;
using StoreAppDB.Interfaces;
using StoreAppDB;

namespace StoreAppLib
{
    public class BaseballBatActions : IBaseballBatActions
    {
        private StoreAppContext context;
        private IBaseballBatRepoActions batRepo;

        public BaseballBatActions(StoreAppContext context, IBaseballBatRepoActions batRepo)
        {

            this.context = context;
            this.batRepo = batRepo;

        }
        public BaseballBat GetBaseballBatById(int id)
        {

            return batRepo.GetBaseballBatById(id);
        }

        List<BaseballBat> IBaseballBatActions.GetAllBaseballBats()
        {
            return batRepo.GetAllBaseballBats();
        }

        public void AddBaseballBat(BaseballBat newBaseballBat)
        {

            batRepo.AddBaseballBatIntoTableAsync(newBaseballBat);
        }

        public void UpdateBaseballBat(BaseballBat bat)
        {
            batRepo.UpdateBaseballBat(bat);
        }

        public void DeleteBaseballBat(BaseballBat bat)
        {
            batRepo.DeleteBaseballBat(bat);
        }
    }
}