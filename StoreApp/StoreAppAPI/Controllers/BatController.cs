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
    public class BatController : ControllerBase
    {

        private readonly IBatService batService;

        public BatController(IBatService batActions)
        {
            batService = batActions;
        }
        ///   <remarks>
        ///    This my Bats Controller That has two methdos Curentlyu
        ///   </remarks>


        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllBats() {


            try { 
                return Ok(batService.GetAllBats()); 
            }
            catch (Exception) { return BadRequest(); }

        }
        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetBatById(int id)
        {


            try { 
                return Ok(batService.GetBatById(id)); 
            }
            catch (Exception) 
            { 
                return BadRequest(); 
            }

        }

        [HttpGet("get/name/{name}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetBatByName(string name)
        {

            try
            {
                return Ok(batService.GetBatByName(name));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult AddBat(Bat bat)
        {
            try
            {
                batService.AddBat(bat);
                
                return CreatedAtAction("AddBaseballBat", bat);
            }
            catch (Exception){ return BadRequest(); }

        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult UpdateBat(Bat bat) 
        {
            try
            {
                batService.UpdateBat(bat);
                return CreatedAtAction("UpdateBat", bat);            
            }
            catch { return BadRequest(); }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult DeleteBat(Bat bat)
        {
            try
            {
                batService.DeleteBat(bat);
                return Ok();
            }
            catch { return BadRequest(); }
        }

    }
}
