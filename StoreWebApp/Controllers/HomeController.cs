using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreWebApp.Models;

namespace StoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string url = "https://localhost:44317/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Sends model for use in Login
        [HttpGet]
        public ViewResult Login()
        {
            var cusModel = new Customer();
          
            
            return View(cusModel);

        }

        //model is returned and credentials checked against api results
        [HttpPost]
        public IActionResult Login(Customer cusModel)
        {
            var invModel = new Inventory();
            invModel.LocationId = cusModel.LocationId;
            HttpContext.Session.SetObject("Inventory", invModel);

            if (ModelState.IsValid) 
            {
                using (var client = new HttpClient()) 
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"customer/get/{cusModel.Email}");

                    var result = response.Result;

                    if (result.IsSuccessStatusCode) 
                    {
                        var jsonString = result.Content.ReadAsStringAsync();

                        jsonString.Wait();

                        var checkedUser = JsonConvert.DeserializeObject<Customer>(jsonString.Result);

                        if (checkedUser.Email==cusModel.Email && checkedUser.Password == cusModel.Password) 
                        {
                            HttpContext.Session.SetObject("Customer", checkedUser);

                            return RedirectToAction("GetInventoryByLocationId", "Customer");
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "Invalid information");
                            return View(cusModel);
                        }
                    }
                }

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
