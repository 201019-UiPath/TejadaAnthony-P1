using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppDB.Models;
using StoreAppLib;

namespace StoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLineItem(OrderItem item)
        {
            try
            {
                orderItemService.AddOrderItem(item);
                return CreatedAtAction("AddOrderItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrderItem(OrderItem item)
        {
            try
            {
                orderItemService.UpdateOrderItem(item);
                return CreatedAtAction("UpdateOrderItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrderItem(OrderItem item)
        {
            try
            {
                orderItemService.DeleteOrderItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{orderId}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrderItemsByOrderId(int orderId)
        {
            try
            {
                return Ok(orderItemService.GetAllOrderItemsByOrderId(orderId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
