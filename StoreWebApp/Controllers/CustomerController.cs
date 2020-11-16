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
        public IActionResult GetInventoryByLocationId() {

            customer = HttpContext.Session.GetObject<Customer>("Customer");
            inventory = HttpContext.Session.GetObject<Inventory>("Inventory");

            if (customer == null)
            {
                return RedirectToAction("Login", "Home");
            }
        
            
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
         
            return View();
        }


        public IActionResult AddCartItem(int BaseballBatId, int Quantity) {

            customer = HttpContext.Session.GetObject<Customer>("Customer");
            BaseballBat baseballBat = new BaseballBat();

            if (customer == null)
            {
                return RedirectToAction("Login", "Home");
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var response = client.GetAsync($"BaseballBat/get/{BaseballBatId}");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode) {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var bat = JsonConvert.DeserializeObject<BaseballBat>(jsonString.Result);
                    baseballBat = bat;
                }

                CartItem item = new CartItem();

                item.BaseballBatId = BaseballBatId;
                item.BaseballBat = baseballBat;
                item.Quantity = Quantity;

                customer.cart.Total += baseballBat.ProductPrice * Quantity;
                customer.cart.CartItem.Add(item);
                var location = HttpContext.Session.GetObject<Inventory>("Inventory");
                HttpContext.Session.SetObject("Customer", customer);
                return RedirectToAction("GetInventoryByLocationId");

            }
        }

        public IActionResult GetCart() 
        {
            var user = HttpContext.Session.GetObject<Customer>("Customer");

            if (user == null) 
            {
                return RedirectToAction("Login", "Home");
            }

            return View(user.cart);
        }







    }
}
