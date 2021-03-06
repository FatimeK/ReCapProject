using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarImagesController:ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]

        public IActionResult GetAll( )
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getimagesbyid")]

        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]

        public IActionResult Delete([FromForm] int imageId)
        {
            var image = _carImageService.GetById(imageId).Data;
            var result = _carImageService.Delete(image);

            if (result.Success)
            {
                System.IO.File.Delete(image.ImagePath);
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add(List<IFormFile> images,[FromForm]CarImage carImage)
        {
            var guidKey = Guid.NewGuid().ToString();
            guidKey = Path.ChangeExtension(guidKey, "resm uzantısı");
            var filepath = @"C:\Users\Fatime Kıran\source\repos\ReCapProject\WebAPI\Images\indir.jpg" + guidKey;

            IResult result = null;

            foreach (var image in images)
            {

                if(image.Length > 0)
                {
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    carImage.Date = DateTime.Now;
                    carImage.ImagePath = filepath;
                    carImage.ImageId = 0;
                    result = _carImageService.Add(carImage);
                }

            }

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);


        }

        [HttpPost("update")]

        public async Task<IActionResult> Update(IFormFile image,[FromForm] int imageId)
        {
            var guidKey = Guid.NewGuid().ToString();
            guidKey = Path.ChangeExtension(guidKey, "jpg");
            var filePath = @"C:\Users\Fatime Kıran\source\repos\ReCapProject\WebAPI\Images\" + guidKey;

            IResult result = null;
            if(image.Length > 0)
            {
                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                var carImage = _carImageService.GetById(imageId).Data;
                carImage.ImagePath = filePath;
                carImage.Date = DateTime.Now;
                result = _carImageService.Update(carImage);

                
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
