using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppLib;
using StoreAppDB.Models;

namespace StoreAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemActions _cartitem;

        public CartItemController(ICartItemActions cartitem)
        {
            _cartitem = cartitem;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartItem(CartItem item)
        {
            try
            {
                _cartitem.AddCartItem(item);

                return CreatedAtAction("AddCartItem", item);
            }
            catch (Exception) { return BadRequest(); }

        }
    }
}
