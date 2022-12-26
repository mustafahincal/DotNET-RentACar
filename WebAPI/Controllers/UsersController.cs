using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
      public class UsersController : Controller
      {
            IUserService _userService;
            public UsersController(IUserService userService)
            {
                  _userService = userService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                  var result = _userService.GetAll();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                  var result = _userService.GetById(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("add")]
            public IActionResult Add(User user)
            {
                  var result = _userService.Add(user);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(DeleteUserDto deleteUserDto)
            {
                  var result = _userService.Delete(deleteUserDto);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update(UpdateUserDto updateUserDto)
            {
                  var result = _userService.Update(updateUserDto);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
      }
}
