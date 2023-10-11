using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class RentalsController : Controller
      {
            IRentalService _rentalService;
            public RentalsController(IRentalService rentalService)
            {
                  _rentalService = rentalService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                  var result = _rentalService.GetAll();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                  var result = _rentalService.GetById(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getrentaldetails")]
            public IActionResult GetRentalDetails()
            {
                  var result = _rentalService.GetRentalDetails();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getrentaldetailsbyid")]
            public IActionResult GetRentalDetailsById(int carId)
            {
                  var result = _rentalService.GetRentalDetailsById(carId);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getrentaldetailsbyuserid")]
            public IActionResult GetRentalDetailsByUserId(int userId)
            {
                  var result = _rentalService.GetRentalDetailsByUserId(userId);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }



            [HttpPost("add")]
            public IActionResult Add(RentCarDto rentCarDto)
            {
                  var result = _rentalService.Add(rentCarDto);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update(UpdateRentalDto updateRentalDto)
            {
                  var result = _rentalService.Update(updateRentalDto);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("delete")]
            public IActionResult Delete(int id)
            {
                  var result = _rentalService.Delete(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
      }
}
