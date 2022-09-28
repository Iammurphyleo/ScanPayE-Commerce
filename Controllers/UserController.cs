using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scanpay.AuthenticationAndAuthorization;
using Scanpay.Dtos;
using Scanpay.Implementation.Service;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        
        public UserController(IUserService userService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _userService = userService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync() 
        {
            var user = await _userService.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet("UserId/{id}")]
        public async Task<IActionResult> GetUserAsync([FromRoute]int id) 
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }


        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email) 
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok(user);
        }


        [HttpPost ]
        [Route("token")]
        public async Task<IActionResult> LogInAsync([FromBody]LogInRequestModel model) 
        {
            var user = await _userService.LogInAsync(model);
            if(user == null) return BadRequest();

            var token = _jwtAuthenticationManager.GenerateToken(user);
            var response = new LoginResponseModel
            {
                Token = token,
                Data = user,
                UserRoles = user.UserRoles,
                
            };
            return Ok(response);
        
        }
    }
}
