using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenDevAPI.Authentication;
using ZenDevLibrary.DbModels;

namespace ZenDevAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IJwtAuthenticationManager _jwtAuthenticationManager;
        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Admin admin)
        {
            var token =_jwtAuthenticationManager.Authenticate(admin.Username, admin.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

    }
}
