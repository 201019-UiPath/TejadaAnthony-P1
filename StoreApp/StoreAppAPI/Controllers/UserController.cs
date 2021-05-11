using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StoreAppDB;
using StoreAppDB.Models;
using StoreAppLib;
using System;
using System.Collections.Generic;

namespace StoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICartService cartService;

        public UserController(IUserService userService, ICartService cartService)
        {
            this.userService = userService;
            this.cartService = cartService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult AddUser(User user)
        {
            try
            {
                userService.AddUser(user);
                return CreatedAtAction("AddUser", user);
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
        public IActionResult UpdateUser(User user)
        {
            try
            {
                userService.UpdateUser(user);
                return CreatedAtAction("UpdateUser", user);
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
        public IActionResult DeleteUser(User user)
        {
            try
            {
                userService.DeleteUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(userService.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(userService.GetUserById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{email}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                return Ok(userService.GetUserByEmail(email));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult SignIn(User user)
        {
            try
            {
                

                User signedInUser = userService.GetUserByEmail(user.email);

                if (signedInUser.password != user.password)
                {
                    
                    return StatusCode(403);
                }
                else
                {
                   
                    return Ok(signedInUser);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signup/cust")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult SignUpCust(User user)
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                if (ValidationService.EmailAvailable(user.email, users) == false)
                {
                    return StatusCode(409);
                }

                if (ValidationService.ValidEmail(user.email) == false)
                {
                    return StatusCode(406);
                }

                if (ValidationService.ValidName(user.name) == false)
                {
                    return BadRequest();
                }

                user.type = StoreAppDB.Models.User.userType.Customer;

                userService.AddUser(user);

                User createdUser = userService.GetUserByEmail(user.email);

                Cart cart = new Cart();
                cart.userId = createdUser.id;
                cartService.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signup/mgr")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult SignUpMgr(User user)
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                if (ValidationService.EmailAvailable(user.email, users) == false)
                {
                    return StatusCode(409);
                }

                if (ValidationService.ValidEmail(user.email) == false)
                {
                    return StatusCode(406);
                }

                if (ValidationService.ValidName(user.name) == false)
                {
                    return BadRequest();
                }

                user.type = StoreAppDB.Models.User.userType.Manager;

                userService.AddUser(user);

                User createdUser = userService.GetUserByEmail(user.email);

                Cart cart = new Cart();
                cart.userId = createdUser.id;
                cartService.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
