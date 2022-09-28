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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CreateCategoryRequestModel model)
        {
            var category = await _categoryService.AddCategoryAsync(model);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {
            var category = await _categoryService.DeleteCategoryAsync(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var category = await _categoryService.GetAllCategoriesAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }

        [HttpGet("GetCategoryByName/{name}")]
        public async Task<IActionResult> GetCategoryByNameAsync([FromRoute] string name)
        {
            var category = await _categoryService.GetCategoryByNameAsync(name);
            return Ok(category);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody]UpdateCategoryRequestModel model) 
        {
            var category = await _categoryService.UpdateCategoryAsync(id, model);
            return Ok(category);
        }






    }


    
    
}
