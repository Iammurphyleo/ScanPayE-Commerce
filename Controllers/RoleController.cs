using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] CreateRoleRequestModel model)
        {
            var role = await _roleService.AddRoleAsync(model);
            return Ok(role);
        }

        [HttpDelete(" DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRoleAsync([FromRoute] int id)
        {
            var role = await _roleService.DeleteRoleAsync(id);
            return Ok(role);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var role = await _roleService.GetAllRolesAsync();
            return Ok(role);
        }

        [HttpGet("GetAllStaffRolesAsync")]
        public async Task<IActionResult> GetAllStaffRolesAsync() 
        {
            var role = await _roleService.GetAllStaffRolesAsync();

            return Ok(role);
        }


        [HttpGet("GetRole/{id}")]
        public async Task<IActionResult> GetRoleAsync([FromRoute]int id) 
        {
            var role = await _roleService.GetRoleAsync(id);

            return Ok(role);
        }

        [HttpPut("UpdateRoleAsync/{id}")]
        public async Task<IActionResult> UpdateRoleAsync([FromRoute]int id, [FromBody]UpdateRoleRequestModel model) 
        {
            var role = await _roleService.UpdateRoleAsync(id, model);

            return Ok(role);
        }



    }
}
