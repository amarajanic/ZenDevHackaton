using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDevLibrary.Interfaces;
using ZenDevLibrary.Services;
using ZenDevAPI.Models;
using ZenDevLibrary.DbModels;

namespace ZenDevAPI.Controllers
{
    [Route("api/[controller]")]

    [Produces("application/json")]
    [ApiController]
    public class PostController : Controller
    {
        IPostService _postService;
        // GET: PostController
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Approved")]
        public async Task<IActionResult> GetAllApproved()
        {
            try
            {
                List<Post> posts = await _postService.GetAllApproved();

                var postVM = posts.Select(x => new PostVM
                {
                    ID = x.ID,
                    Title = x.Title,
                    TypeID = x.TypeID,
                    Name = x.Name,
                    Text = x.Text,
                    //File = x.File,
                    LocationID = x.LocationID,
                    IsPositive = x.IsPositive
                });

                return Ok(postVM.ToList());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

        }
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("NotApproved")]
        public async Task<IActionResult> GetAllNotApproved()
        {
            try
            {
                List<Post> posts = await _postService.GetAllNotApproved();

                var postVM = posts.Select(x => new PostVM
                {
                    ID = x.ID,
                    Title = x.Title,
                    TypeID = x.TypeID,
                    Name = x.Name,
                    Text = x.Text,
                    //File = x.File,
                    LocationID = x.LocationID,
                    IsPositive = x.IsPositive
                });

                return Ok(postVM.ToList());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);

            }



            //return Ok();

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromBody] PostVM model)
        {
            try
            {
                if (model.Name == "")
                    model.Name = "Anonymous";
                _postService.Insert(new ZenDevLibrary.DbModels.Post
                {
                    Title = model.Title,
                    IsApproved = false,
                    IsPositive = model.IsPositive,
                    LocationID = model.LocationID,
                    Name = model.Name,
                    Text = model.Text,
                    File = model.File,
                    TypeID = model.TypeID
                });

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status400BadRequest, err.Message);

            }

        }

        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            try
            {
                _postService.Delete(ID);

                return Ok("Object deleted!");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status409Conflict, err.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult Update(int ID, bool isApproved)
        {
            try
            {
                _postService.Update(ID, isApproved);

                return Ok("Updated!");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, err.Message);
            }

           
        }

    }
}
