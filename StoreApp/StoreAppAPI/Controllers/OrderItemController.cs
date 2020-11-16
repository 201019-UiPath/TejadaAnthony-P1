using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppDB.Models;
using StoreAppLib;

namespace StoreAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemActions _orderItemActions;

        public OrderItemController(IOrderItemActions orderItemActions)
        {
            _orderItemActions = orderItemActions;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddOrderItem(OrderItem orderItem)
        {

            try
            {
                _orderItemActions.AddOrderItem(orderItem);
                return CreatedAtAction("AddOrderItem", orderItem);
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
