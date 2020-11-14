using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace StoreWebApp.Controllers
{
    public class CustomerController : Controller
    {
        const string url = "https://localhost:44317/";
        private Customer customer;
        private Inventory inventory;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetInventoryByLocationId(int id) {

            customer = HttpContext.Session.GetObject<Customer>("Customer");
            inventory = HttpContext.Session.GetObject<Inventory>("Inventory");

            if (customer == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient()) 
                {
                    client.BaseAddress = new Uri(url);

                 
                    var response = client.GetAsync($"Inventory/get/{inventory.LocationId}");
                    response.Wait();

                    var result = response.Result;

                    if (result.IsSuccessStatusCode) 
                    {
                        var jsonString = result.Content.ReadAsStringAsync();
                        jsonString.Wait();

                        var invModel = JsonConvert.DeserializeObject<List<Inventory>>(jsonString.Result);
                        return View(invModel);
                    }
                }
            }

            return View();
        }
    }
}
