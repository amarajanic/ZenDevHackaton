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
    public class LocationController : Controller
    {
        ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            List<Location> locations = await _locationService.GetAll();

            var locationVM = locations.Select(x => new LocationVM
            {
                ID = x.ID,
                Lat = x.Lat,
                Long = x.Long,
                Name = x.Name
            });
            return Ok(locationVM.ToList());

            }
            catch (Exception err)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] LocationVM model)
        {
            try
            {

                _locationService.Insert(new ZenDevLibrary.DbModels.Location
                {
                    Lat = model.Lat,
                    Long = model.Long,
                    Name = model.Name
                });

                return Ok("Object created!");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);

            }
        }
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                _locationService.Delete(ID);
                return Ok("Object deleted");

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status409Conflict, err.Message);
            }
        }
    }
}
