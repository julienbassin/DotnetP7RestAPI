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
    [Route("api/user")]
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
                var result = _userService.FindAll();
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
                var result = _userService.FindById(userId);
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
                _userService.Add(editUserDTO);
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var user = _userService.FindById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                _userService.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequestExceptionHandler(e, nameof(Delete));
            }
        }
    }
}