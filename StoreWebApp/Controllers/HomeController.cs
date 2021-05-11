using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            invModel.LocationId = cusModel.Location;
            HttpContext.Session.SetObject("Inventory", invModel);

            _logger.LogInformation("entering login ");
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
                        var location = HttpContext.Session.GetObject<Inventory>("Inventory");
                        checkedUser.Location = location.LocationId;

                        if (checkedUser.Email==cusModel.Email && checkedUser.Password == cusModel.Password) 
                        {
                            checkedUser.cart = new Cart();
                            HttpContext.Session.SetObject("Customer", checkedUser);

                            return RedirectToAction("GetInventoryByLocationId", "Customer");
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "Invalid information");
                            return View(checkedUser);
                        }
                    }
                }


            }

            return View();
        }

        [HttpGet]
        public ViewResult Signup() 
        {
            Customer newCus = new Customer();
       
            return View(newCus);
        }

        [HttpPost]
        public IActionResult Signup(Customer newCus)
        {
            Customer customer = new Customer();

            customer.Name = newCus.Name;
            customer.Email = newCus.Email;
            customer.Password = newCus.Password;
            customer.cart = null;
            customer.Location = 1;
            _logger.LogInformation("entering signup ");
            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(url);

                var json = JsonConvert.SerializeObject(customer);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("customer/add", data);
                response.Wait();

                var result = response.Result;

            }



                return RedirectToAction("Login", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
