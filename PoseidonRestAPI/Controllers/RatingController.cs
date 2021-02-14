using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : Controller
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Rating>> GetAll()
        {
            try
            {
                var result = _ratingService.FindAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{ratingId}")]
        public IActionResult FindById(int ratingId)
        {
            try
            {
                var result = _ratingService.FindById(ratingId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditRatingDTO ratingDTO)
        {
            try
            {
                _ratingService.Add(ratingDTO);
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
                var curvePoint = _ratingService.FindById(Id);
                if (curvePoint == null)
                {
                    return NotFound();
                }
                _ratingService.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}