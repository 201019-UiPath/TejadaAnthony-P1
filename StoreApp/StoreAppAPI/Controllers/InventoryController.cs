using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppLib;

namespace StoreAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryActions _inventoryActions;

        public InventoryController(IInventoryActions inventoryActions)
        {
            this._inventoryActions = inventoryActions;
        }


        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetInventoryByLocationId(int id) {

            try { return Ok(_inventoryActions.GetInventoryByLocationId(id)); }
            catch (Exception) { return BadRequest(); }
        }
    }
}
