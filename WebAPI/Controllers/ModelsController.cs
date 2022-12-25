using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
      [Route("api/[controller]")]
      // 
      [ApiController]

      public class ModelsController : Controller
      {
            IModelService _modelService;
            public ModelsController(IModelService modelService)
            {
                  _modelService = modelService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                  var result = _modelService.GetAll();
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }


            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                  var result = _modelService.GetById(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
            [HttpPost("add")]
            public IActionResult Add(AddModelDto addModelDto)
            {
                  var result = _modelService.Add(addModelDto);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("delete")]
            public IActionResult Delete(Model model)
            {
                  var result = _modelService.Delete(model);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("update")]
            public IActionResult Update(Model model)
            {
                  var result = _modelService.Update(model);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }

            [HttpGet("getmodelsbybrandid")]
            public IActionResult GetModelsByBrandId(int id)
            {
                  var result = _modelService.GetModelsByBrandId(id);
                  if (result.Success)
                  {
                        return Ok(result);
                  }
                  return BadRequest(result);
            }
      }
}
