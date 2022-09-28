using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ZXing;
using ZXing.CoreCompat.System.Drawing;

namespace Scanpay.Controllers
{
    [Route("api/[scanner]")]
    [ApiController]
    public class ScannerController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnvironment;

        public ScannerController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }


    }
}
