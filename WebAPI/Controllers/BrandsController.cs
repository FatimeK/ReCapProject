using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BrandsController : Controller
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success == true)
            {
                return Ok(result.Data);

            }

            return BadRequest(result.Message);



        }

        [HttpGet("getbyid")]
        public IActionResult GetByBrandId(int brandid)
        {
            var result = _brandService.GetById(brandid);
            if (result.Success == true)
            {
                foreach (var data in result.Data)
                {
                    return Ok(data);
                }

            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}