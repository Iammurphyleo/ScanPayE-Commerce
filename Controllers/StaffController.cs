using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scanpay.Dtos;
using Scanpay.EmailServices;
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
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;
        private readonly IMailServices _mailService;


        public StaffController(IStaffService staffService, IMailServices mailService)
        {
            _staffService = staffService;
            _mailService = mailService;
                     
        }

        [HttpPost]
        public async Task<IActionResult> AddStaffAsync([FromBody]CreateStaffRequestModel model) 
        {
            var staff = await _staffService.AddStaffAsync(model);

            var staffs = $"Dear {model.FirstName} {model.LastName}, you have been registered as a staff on scanpay shopping application based on the role you applied for." +
                $"Kindly bear in my mind your staff-code is your pass-key to log you in into your role dash-board. Thank you";

            _mailService.SendingMail(model.Email, staffs, "Wellcome");
                                                                
            return Ok(staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAsync([FromRoute]int id) 
        {
            var staff = await _staffService.DeleteStaffAsync(id);
            return Ok(staff);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffsAsync() 
        {
            var staff = await _staffService.GetAllStaffsAsync();
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffAsync([FromRoute]int id) 
        {
            var staff = await _staffService.GetStaffAsync(id);
            return Ok(staff);
        }


        [HttpGet ("GetbyStaffCode/{staffCode}")]
        public async Task<IActionResult> GetStaffByStaffcodeAsync([FromRoute] string staffCode) 
        {
            var staff = await _staffService.GetStaffByStaffcodeAsync(staffCode);
            return Ok(staff);
        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffAsync([FromRoute]int id,[FromBody] UpdateStaffRequestModel model) 
        {
            var staff = await _staffService.UpdateStaffAsync(id, model);
            return Ok(staff);
        }








    }
}
