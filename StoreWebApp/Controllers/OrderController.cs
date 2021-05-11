using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NpgsqlTypes;
using StoreWebApp.Models;

namespace StoreWebApp.Controllers
{
    public class OrderController : Controller
    {
        const string url = "https://localhost:44317/";
        private Customer customer;
        public IActionResult AddOrder(Cart cart) {

            customer = HttpContext.Session.GetObject<Customer>("Customer");

            if (User == null) 
            {
                return RedirectToAction("Login", "Home");
            }
            var location = HttpContext.Session.GetObject<Inventory>("Inventory");


            
            Order order = new Order();
            order.LocationId = location.LocationId;
            order.Total = cart.Total;
            order.OrderDate = DateTime.Now;
            NpgsqlDateTime npgsqlDateTime = order.OrderDate;
            order.CustomerId = customer.Id;

            using (var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(url);

                var json = JsonConvert.SerializeObject(order);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("order/add", data);
                response.Wait();

                while (response.Result.IsSuccessStatusCode) 
                {
                    response = client.GetAsync($"order/get/{npgsqlDateTime}");
                    response.Wait();
                    var result = response.Result.Content.ReadAsStringAsync();
                    var newOrder = JsonConvert.DeserializeObject<Order>(result.Result);

                    order.Id = newOrder.Id;

                    foreach (var item in customer.cart.CartItem) 
                    {
                        BaseballBat baseballBat = item.BaseballBat;

                        OrderItem orderItem = new OrderItem();

                        orderItem.OrderId = order.Id;
                        orderItem.BaseballBatId = item.BaseballBatId;
                        orderItem.Cost = baseballBat.ProductPrice;
                        orderItem.Quantity = item.Quantity;

                        json = JsonConvert.SerializeObject(orderItem);
                        data = new StringContent(json, Encoding.UTF8, "application/json");
                        response = client.PostAsync("OrderItem/add",data);
                        response.Wait();
                    }

                    customer.cart.CartItem.Clear();

                    HttpContext.Session.SetObject("Customer", customer);
                    return View("AddOrder", order);
                }

            }

                return View();
        }
    }
}
