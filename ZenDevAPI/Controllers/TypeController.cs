using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDevAPI.Models;
using ZenDevLibrary.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenDevAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        ITypeService _typeService;

        // GET: PostController
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: api/<TypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                List<ZenDevLibrary.DbModels.Type> types = await _typeService.Get();

                var typeVM = types.Select(x => new TypeVM { Name = x.Name, ID = x.ID });

                return Ok(typeVM.ToList());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
                
            }


            
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetById(int ID)
        {
            try
            {
                var subType = await _typeService.GetByID(ID);
                TypeVM model = new TypeVM { Name = subType.Name, ID = subType.ID };

                return Ok(model);
            }
            catch (Exception err)
            {

                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }

          
        }
        [HttpPost]
        public IActionResult Post([FromBody] TypeVM model)
        {
            try
            {
                _typeService.Insert(new ZenDevLibrary.DbModels.Type
                {
                    Name = model.Name,
                    
                 
                });

                return Ok("Object created!");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);
            }

           
        }
        [HttpPut("{ID}")]
        public IActionResult Update(int ID, SubTypeVM request)
        {
            try
            {
                var subType = new ZenDevLibrary.DbModels.Type
                {
                    Name = request.Name
                };
                _typeService.Update(ID, subType);
                return Ok("Object modified");
            }
            catch (Exception err)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

           
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                _typeService.Delete(ID);
                return Ok("Object deleted");
            }
            catch (Exception err)
            { 
                return StatusCode(StatusCodes.Status409Conflict, err.Message);
            }

            
        }
    }
}
