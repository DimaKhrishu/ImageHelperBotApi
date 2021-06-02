using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageHelperBot.Clients;
using ImageHelperBot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;

namespace ImageHelperBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageHelperBotController : ControllerBase
    {
        

        private readonly ILogger<ImageHelperBotController> _logger;
        private readonly BackgroundRemove _bgRemover;
        private readonly JpgToPdf _convPdf;
        

        public ImageHelperBotController(ILogger<ImageHelperBotController> logger, BackgroundRemove bgRemover, JpgToPdf convPdf)
        {
            _logger = logger;
            _bgRemover = bgRemover;
            _convPdf = convPdf;
          
        }

        [HttpGet("removebg")]
        public async Task<Stream> RemoveBackgound([FromQuery]Parametrs parametrs)
        {
           
            var arr = await _bgRemover.RemoveBg(parametrs.image_url);
            return arr;
           

        }
        [HttpGet("convertpdf")]
        public async Task<String> JpgToPdf([FromQuery] Parametrs parametrs)
        {
            var result =await _convPdf.ConvertPdf(parametrs.File);
            return result;
        }
        //[HttpGet("getTgImage")]
        //public async Task<String> GetTgImage(string id)
        //{
        //    var result = await _tgImage.GetImage(id);
        //    return result;
        //}
    }
}
