using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scanpay.Dtos;
using Scanpay.Implementation.Service;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.CoreCompat.System.Drawing;

namespace Scanpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemController(IItemService itemService, IWebHostEnvironment hostEnvironment)
        {
            _itemService = itemService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost("AddItemAsync")]
        public async Task<IActionResult> AddItemAsync([FromBody]CreateItemRequestModel model) 
        {
            var item = await _itemService.AddItemAsync(model);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute]int id) 
        {
           var item =  await _itemService.DeleteItemAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemsAsync() 
        {
            var item = await _itemService.GetAllItemsAsync();
            return Ok(item);
        }

        [HttpGet("GetItemAsync/{id}")]
        public async Task<IActionResult> GetItemAsync([FromRoute]int id) 
        {
            var item = await _itemService.GetItemAsync(id);
            return Ok(item);
        }

        [HttpGet("GetItemByQRCodeAsync/{qRCode}")]
        public async Task<IActionResult> GetItemByQRCodeAsync([FromRoute]string qRCode) 
        {
            var item = await _itemService.GetItemByQRCodeAsync(qRCode);
            return Ok(item);
        }

        [HttpGet("GetItemNameAsync/{name}")]
        public async Task<IActionResult> GetItemNameAsync([FromRoute]string name) 
        {
            var item = await _itemService.GetItemNameAsync(name);
            return Ok(item);
        }

        [HttpPut("UpdateItemAsync/{id}")]
        public async Task<IActionResult> UpdateItemAsync([FromRoute]int id, [FromBody]UpdateItemRequestModel model) 
        {
            var item = await _itemService.UpdateItemAsync(id, model);
            return Ok(item);
        }

        [HttpGet("SearchItems/{searchText}")]
        public IActionResult SearchItems([FromRoute]string searchText) 
        {
            var item =  _itemService.SearchItems(searchText);

            return Ok(item);
        }

       /* [HttpPost("{file}")]
        public string ReadQRCode([FromRoute] IFormFile file)
        {
            string fileName = file.FileName;
            string webRootPath = _hostEnvironment.WebRootPath;
            var path = webRootPath + "\\qrimage\\" + fileName;
            string qRCode = "";
            var reader = new BarcodeReaderGeneric();
            Bitmap image = (Bitmap)Image.FromFile(path);
            using (image)
            {
                LuminanceSource source = new BitmapLuminanceSource(image);
                Result result = reader.Decode(source);
                qRCode += result.Text;
            }
            return qRCode;
        }*/

    }
}
