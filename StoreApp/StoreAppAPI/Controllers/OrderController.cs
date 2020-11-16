using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppDB;
using StoreAppLib;
using StoreAppDB.Models;

namespace StoreAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderActions _orderActions;

        public OrderController(IOrderActions orderActions)
        {
            _orderActions = orderActions;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllOrders()
        {
            try
            {
                return Ok(_orderActions.GetAllOrders());
            }
            catch (Exception) { return BadRequest(); }

        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetOrdersByCustomerId(int id) {

            try
            {
                return Ok(_orderActions.GetOrdersByCustomerId(id));
            }
            catch(Exception) { return BadRequest(); }
        }

        [HttpGet("get/{date}")]
        [Produces("application/json")]
        public IActionResult GetOrderByDate(string date)
        {

            try
            {
                return Ok(_orderActions.GetOrderByDate(date));
            }
            catch (Exception) { return BadRequest(); }
        }
        [HttpGet("get/{locId}")]
        [Produces("application/json")]
        public IActionResult GetOrdersByLocationId(int locId)
        {

            try
            {
                return Ok(_orderActions.GetOrdersByLocationId(locId));
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddOrder(Order order)
        {

            try
            {
                _orderActions.AddNewOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
