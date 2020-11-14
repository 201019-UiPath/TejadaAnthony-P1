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
    [Route("[controller]")]
    [ApiController]
    public class BaseballBatController : ControllerBase
    {

        private readonly IBaseballBatActions _batActions;

        public BaseballBatController(IBaseballBatActions batActions)
        {
            _batActions = batActions;
        }
        ///   <remarks>
        ///    This my Bats Controller That has two methdos Curentlyu
        ///   </remarks>


        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors]
        public IActionResult GetAllBats() {


            try { 
                return Ok(_batActions.GetAllBaseballBats()); 
            }
            catch (Exception) { return BadRequest(); }

        }
        [HttpGet("get/{id}")]
        [Produces("application/json")]
        [EnableCors("MyAllowSpecificOrigins")]
        public IActionResult GetBatById(int id)
        {


            try { 
                return Ok(_batActions.GetBaseballBatById(id)); 
            }
            catch (Exception) 
            { 
                return BadRequest(); 
            }

        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("MyAllowSpecificOrigins")]
        public IActionResult AddBaseballBat(BaseballBat bat)
        {
            try
            {
                _batActions.AddBaseballBat(bat);
                
                return CreatedAtAction("AddBaseballBat", bat);
            }
            catch (Exception){ return BadRequest(); }

        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("MyAllowSpecificOrigins")]
        public IActionResult EditBaseballBat(BaseballBat bat) 
        {
            try
            {
                _batActions.UpdateBaseballBat(bat);
                return CreatedAtAction("EditBaseballBat", bat);            
            }
            catch { return BadRequest(); }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("MyAllowSpecificOrigins")]
        public IActionResult DeleteBaseballBat(BaseballBat bat)
        {
            try
            {
                _batActions.DeleteBaseballBat(bat);
                return Ok();
            }
            catch { return BadRequest(); }
        }

    }
}
