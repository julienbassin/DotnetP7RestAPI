using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = _userService.FindAllUsers();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{userId}")]
        public IActionResult FindById(int userId)
        {
            try
            {
                var result = _userService.FindUserById(userId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditUserDTO editUserDTO)
        {
            try
            {
                _userService.CreateUser(editUserDTO);
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult Delete(int userId)
        {
            try
            {
                var user = _userService.FindUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                _userService.Delete(userId);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}