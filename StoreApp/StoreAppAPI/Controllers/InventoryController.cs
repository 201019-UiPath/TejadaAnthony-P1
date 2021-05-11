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
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult AddInventoryItem(Inventory item)
        {
            try
            {
                inventoryService.AddInventoryItem(item);
                return CreatedAtAction("AddInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult UpdateInventoryItem(Inventory item)
        {
            try
            {
                inventoryService.UpdateInventoryItem(item);
                return CreatedAtAction("UpdateInventoryItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult DeleteInventoryItem(Inventory item)
        {
            try
            {
                inventoryService.DeleteInventoryItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllInventoryItemsByLocationId(int locationId)
        {
            try
            {
                return Ok(inventoryService.GetAllInventoryItemsByLocationId(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{locationId}/{batId}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetItemByLocationIdBatId(int locationId, int batId)
        {
            try
            {
                return Ok(inventoryService.GetItemByLocationIdBatId(locationId, batId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
