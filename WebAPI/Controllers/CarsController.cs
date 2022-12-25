using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
      [Route("api/[controller]")]
      // 
      [ApiController]

      public class CarsController : Controller
      {
            ICarService _carService;
            public CarsController(ICarService carService)
            {
                  _carService = carService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                  var result = _carService.GetAll();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getcarsbybrandid")]
            public IActionResult GetCarsByBrandId(int id)
            {
                  var result = _carService.GetCarsByBrandId(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getcarsbycolorid")]
            public IActionResult GetCarsByColorId(int id)
            {
                  var result = _carService.GetCarsByColorId(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                  var result = _carService.GetById(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getcardetails")]
            public IActionResult GetCarDetails()
            {
                  var result = _carService.GetCarDetails();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getcardetailsbyid")]
            public IActionResult GetCarDetailsById(int id)
            {
                  var result = _carService.GetCarDetailsById(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getcardetailsbybrandid")]
            public IActionResult GetCarDetailsByBrand(int brandId)
            {
                  var result = _carService.GetCarDetailsByBrand(brandId);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
            [HttpGet("getcardetailsbycolorid")]
            public IActionResult GetCarDetailsByColor(int colorId)
            {
                  var result = _carService.GetCarDetailsByColor(colorId);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("add")]
            public IActionResult Add(Car car)
            {
                  var result = _carService.Add(car);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(Car car)
            {
                  var result = _carService.Delete(car);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update(Car car)
            {
                  var result = _carService.Update(car);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
      }
}
