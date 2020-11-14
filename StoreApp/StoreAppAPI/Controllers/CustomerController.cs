using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StoreAppLib;
using System;

namespace StoreAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerActions _customerActions;

        public CustomerController(ICustomerActions customerActions)
        {
            _customerActions = customerActions;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors]
        public IActionResult GetAllCustomers() {
            try { return Ok(_customerActions.GetAllCustomers()); }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet("get/{email}")]
        [Produces("application/json")]
        [EnableCors]
        public IActionResult GetCustomerByEmail(string email)
        {
            try { return Ok(_customerActions.GetCustomerByEmail(email)); }
            catch (Exception) { return BadRequest(); }
        }


    }
}
