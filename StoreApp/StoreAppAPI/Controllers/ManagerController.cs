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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerActions _managerActions;
        public ManagerController(IManagerActions managerActions)
        {

            this._managerActions = managerActions;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllManagers() {

            try { return Ok(_managerActions.GetAllManagers()); }
            catch (Exception) { return BadRequest(); }
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult AddManager(Manager manager) {

            try {

                _managerActions.AddManager(manager);
                return CreatedAtAction("AddManager", manager);
            }
            catch (Exception) { 
                return BadRequest(); 
            }

        }
    }
}
