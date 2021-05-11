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
    public class BatService : IBatService
    {
        private StoreAppContext context;
        private IBatRepoActions batRepo;

        public BatService(StoreAppContext context, IBatRepoActions batRepo)
        {

            this.context = context;
            this.batRepo = batRepo;

        }

        public void AddBat(Bat bat)
        {
            batRepo.AddBat(bat);
        }

        public void DeleteBat(Bat bat)
        {
            batRepo.DeleteBat(bat);
        }

        public List<Bat> GetAllBats()
        {
            return batRepo.GetAllBats();
        }

        public Bat GetBatById(int id)
        {
            return batRepo.GetBatById(id);
        }

        public Bat GetBatByName(string product)
        {
            return batRepo.GetBatByName(product);
        }

        public void UpdateBat(Bat bat)
        {
             batRepo.UpdateBat(bat);
        }
    }
}