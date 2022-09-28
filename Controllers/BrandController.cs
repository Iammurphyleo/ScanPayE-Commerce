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
    public class BrandController : ControllerBase
    {

        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("AddBrand")]
        public async Task<IActionResult> AddBrandAsync([FromBody] CreateBrandRequestModel model)
        {
            var brand = await _brandService.AddBrandAsync(model);
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandAsync([FromRoute]int id) 
        {
            var brand = await _brandService.DeleteBrandAsync(id);
            return Ok(brand);
        }

        [HttpGet ("GetAll")]
        public async Task<IActionResult> GetAllBrandsAsync() 
        {
            var brand = await _brandService.GetAllBrandsAsync();
            return Ok(brand);
        }

        [HttpGet("GetBrandAsync/{id}")]
        public async Task<IActionResult> GetBrandAsync([FromRoute]int id) 
        {
            var brand = await _brandService.GetBrandAsync(id);
            return Ok(brand);
        }

        [HttpGet("GetBrandByNameAsync/{name}")]
        public async Task<IActionResult> GetBrandBynameAsync([FromRoute] string name)
        {
            var brand = await _brandService.GetBrandByNameAsync(name);
            return Ok(brand);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateBrandAsync([FromRoute]int id, [FromBody] UpdateBrandRequestModel model) 
        {
            var brand = await _brandService.UpdateBrandAsync(id, model);
            return Ok(brand);
        }

    }
}
