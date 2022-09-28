using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scanpay.Dtos;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Scanpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;

        public CartController(ICartService cartService , ICustomerService customerService)
        {
            _cartService = cartService;
            _customerService = customerService;
        }

       [Authorize]
        [HttpPost("CreateCartForItem")]
        public async Task<IActionResult> CreateCartForItem([FromBody] CreateCartRequestModel model)
        {
            var mail = User.FindFirst(ClaimTypes.Email).Value;

            var customer = await _customerService.GetCustomerByEmailAsync(mail);

            model.CustomerId = customer.Id;

            var cart = await _cartService.CreatCartAsync(model);

            return Ok(cart);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartAsync([FromRoute] int id)
        {
            var cart = await _cartService.DeleteCartAsync(id);
            return Ok(cart);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCartAsync()
        {
            var cart = await _cartService.GetAllCartsAsync();

            return Ok(cart);
        }

        [HttpGet("GetCartById/{id}")]
        public async Task<IActionResult> GetCartByIdAsync([FromRoute] int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            return Ok(cart);
        }
        [Authorize]
        [HttpGet("GetCartsByCustomerIdAsync")]
        public async Task<IActionResult> GetCartsByCustomerIdAsync()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var userEmail = await _customerService.GetCustomerByEmailAsync(email);

            var cart = await _cartService.GetCartsByCustomerIdAsync(userEmail.Id);

            return Ok(cart);
        }

        [HttpGet("GetCartsOrderedByDate/{date}")]
        public async Task<IActionResult> GetCartsOrderedByDateAsync([FromRoute] DateTime date) 
        {
            var cart = await _cartService.GetCartsOrderedByDateAsync(date);
            return Ok(cart);
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("UpdateCartAsync")]
        public async Task<IActionResult> UpdateCartAsync([FromBody] UpdateCartRequestModel model)
        {
            var mail = User.FindFirst(ClaimTypes.Email).Value;

            var customer = await _customerService.GetCustomerByEmailAsync(mail);
            var cart = await _cartService.UpdateCartAsync(model , customer.Id);

            return Ok(cart);

        }


    }
}
