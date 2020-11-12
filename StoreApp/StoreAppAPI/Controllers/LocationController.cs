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
    public class LocationController : ControllerBase
    {
        private readonly ILocationActions _locationActions;

        public LocationController(ILocationActions locationActions)
        {
            _locationActions = locationActions;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations() {

            try {

                return Ok(_locationActions.GetAllLocations()); 
                

            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetLocationById(int id)
        {

            try {
                return Ok(_locationActions.GetLocationById(id)); 
              
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
