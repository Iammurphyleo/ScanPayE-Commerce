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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody]CreateStockRequestModel model) 
        {
            var stock = await _stockService.AddStockAsync(model);
            return Ok(stock);
        }

        [HttpDelete("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute]int id) 
        {
            var stock = await _stockService.DeleteStockAsync(id);
            return Ok(stock);
        
        }

        [HttpGet]
        public async Task<IActionResult> GetallStocksAsync() 
        {
            var stock = await _stockService.GetallStocksAsync();
            return Ok(stock);
        }

        [HttpGet("GetStock/{id}")]
        public async Task<IActionResult> GetStock([FromRoute]int id) 
        {
            var stock = await _stockService.GetStockAsync(id);
            return Ok(stock);
        }
    
        [HttpPut("UpdateStock/{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute]int id, [FromBody]UpdateStockRquestModel model) 
        {
            var stock = await _stockService.UpdateStockAsync(id, model);

            return Ok(stock);
        
        }


    }
}
