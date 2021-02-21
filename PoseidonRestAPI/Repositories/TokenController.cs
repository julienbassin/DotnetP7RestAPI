using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Configuration;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : Controller
    {
        private readonly IUserService _userService;
        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateTokens([FromBody] TokenDTO tokenDTO)
        {
            if (!ModelState.IsValid) return BadRequest($"failed to create a token for this user! ");

            var currentUser = _userService.FindUserByName(tokenDTO.Username);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            // check if password is the same in DB

            var token = JsonWebToken.GenerateWebToken(currentUser.Id);
            _userService.SaveJsonWebToken(token, currentUser.Id);
            return Ok(token);
        }
    }
}
