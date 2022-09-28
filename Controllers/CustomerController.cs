
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scanpay.Dtos;
using Scanpay.EmailServices;
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
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMailServices _mailService;


        public CustomerController(ICustomerService customerService, IMailServices mailService)
        {
            _customerService = customerService;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerRequestModel model) 
        {
            var customer = await _customerService.AddCustomerAsync(model);

            var customers = $"Dear {model.FirstName} {model.LastName}, you have successfully registered on scanpay shopping application";

            _mailService.SendingMail(model.Email, customers, "Wellcome");

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id) 
        {
            var customer = await _customerService.DeleteCustomerAsync(id);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() 
        {
            var customer = await _customerService.GetAllCustomersAsync();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute]int id) 
        {
            var customer = await _customerService.GetCustomerAsync(id);

            return Ok(customer);
        }

        [HttpGet("CustomerByEmail/{email}")]
        public async Task<IActionResult> GetCustomerByEmail([FromRoute] string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);

            return Ok(customer);
        }

        [Authorize]
        [HttpPut("UpdateCustomer/{update}")]
        public async Task<IActionResult> UpdateCustomer( [FromBody]UpdateCustomerRequestModel model) 
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;

            var user = await _customerService.GetCustomerByEmailAsync(email);

            var customer = await _customerService.UpdateCustomerAsync(user.Id, model);

            return Ok(customer);
        }


    }
}
