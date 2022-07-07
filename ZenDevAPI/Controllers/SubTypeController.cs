using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDevAPI.Models;
using ZenDevLibrary.DbModels;
using ZenDevLibrary.Interfaces;

namespace ZenDevAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SubTypeController : Controller
    {
        ISubTypeService _subTypeService;
        public SubTypeController(ISubTypeService subTypeService)
        {
            _subTypeService = subTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<SubType> subTypes = await _subTypeService.GetAll();

                var subTypeVM = subTypes.Select(x => new SubTypeVM
                {
                    ID = x.ID,
                    Name = x.Name,
                    TypeID = x.TypeID
                });
                return Ok(subTypeVM.ToList());
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
                SubType subType = await _subTypeService.GetByID(ID);
                SubTypeVM model = new SubTypeVM { Name = subType.Name };

                return Ok(model);

            }
            catch (Exception err)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] SubTypeVM model)
        {
            try
            {
                _subTypeService.Insert(new ZenDevLibrary.DbModels.SubType
                {
                    Name = model.Name,
                    TypeID = model.TypeID
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
                SubType subType = new SubType
                {
                    Name = request.Name,
                    TypeID = request.TypeID
                };
                _subTypeService.Update(ID, subType);
                return Ok("Object modified");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status404NotFound, err.Message);
            }

        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                _subTypeService.Delete(ID);
                return Ok("Object deleted");

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status409Conflict, err.Message);
            }
        }
    }
}
