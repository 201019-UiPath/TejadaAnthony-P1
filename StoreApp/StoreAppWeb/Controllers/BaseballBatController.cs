using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreAppDB;
using StoreAppDB.Interfaces;

namespace StoreAppWeb.Controllers
{
    public class BaseballBatController : Controller
    {
   
        IBaseballBatRepoActions _repo;

        public BaseballBatController(IBaseballBatRepoActions repo)
        {
            _repo = repo;
        }

        public IActionResult Bats()
        {
            var BaseballBat = _repo.GetAllBaseballBats();
            return View(BaseballBat);
        }
    }
}
