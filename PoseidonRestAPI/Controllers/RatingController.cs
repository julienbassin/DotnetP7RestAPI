using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
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
        public IActionResult FindById(int curvePointId)
        {
            try
            {
                var result = _curvePointService.FindById(curvePointId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditCurvePointDTO curvePoint)
        {
            try
            {
                _curvePointService.Add(curvePoint);
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
                var curvePoint = _curvePointService.FindById(Id);
                if (curvePoint == null)
                {
                    return NotFound();
                }
                _curvePointService.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequestExceptionHandler(e, nameof(Delete));
            }
        }
    }
}