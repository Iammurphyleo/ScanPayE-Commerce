using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scanpay.Dtos;
using Scanpay.Enum;
using Scanpay.Implementation.Service;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, IUserService userService, ICustomerService customerService)
        {
            _orderService = orderService;
            _userService = userService;
            _customerService = customerService;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost("CreateOrderForItem")]
        public async Task<IActionResult> CreateOrderForItem()
        {
            
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var userEmail = await _customerService.GetCustomerByEmailAsync(email);
    
            var order = await _orderService.CreateOrderForItemAsync(userEmail.Id);
            

            return Ok(order);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var order = await _orderService.DeleteOrderAsync(id);

            return Ok(order);

        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var order = await _orderService.GetAllOrdersAsync();

            return Ok(order);
        }

        [HttpGet("GetOrderDetails/{id}")]
        public async Task<IActionResult> GetOrderDetails([FromRoute] int id)
        {
            var order = await _orderService.GetOrderAsync(id);

            return Ok(order);
        }

        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id,  OrderStatus status)
        {
            var order = await _orderService.UpdateOrderAsync(id, status);

            return Ok(order);
        }

        [HttpGet("OrderByDate/{date}")]
        public async Task<IActionResult> GetItemsOrderedByDate([FromRoute] DateTime date)
        {
            var order = await _orderService.GetItemsOrderedByDateAsync(date);

            return Ok(order);

        }

        [Authorize]
        [HttpGet("OrderByCustomer")]
        public async Task<IActionResult> GetItemsOrderedByCustomerId()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var userEmail = await _customerService.GetCustomerByEmailAsync(email);

            var order = await _orderService.GetItemsOrderedByCustomerIdAsync(userEmail.Id);
           
            return Ok(order);
        }

        [Authorize]
        [HttpGet("OrderNotClearedByCustomer")]
        public async Task<IActionResult> GetNotClearedItemsOrderedByCustomerIdAsync() 
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var userMail = await _customerService.GetCustomerByEmailAsync(email);

            var order = await _orderService.GetNotClearedItemsOrderedByCustomerIdAsync(userMail.Id);

            return Ok(order);
        }


        [HttpGet("OrderByReference/{reference}")]
        public async Task<IActionResult> GetItemsOrderedByReference([FromRoute] string reference)
        {
            var order = await _orderService.GetItemsOrderedByReferenceAsync(reference);

            return Ok(order);
        }

        [HttpGet("OrderByCustomerEmail/{email}")]
        public async Task<IActionResult> GetItemsOrderedByCustomerEmail([FromRoute] string email) 
        {
            var order = await _orderService.GetItemsOrderedByCustomerEmailAsync(email);

            return Ok(order);
        }

        
    }




}

