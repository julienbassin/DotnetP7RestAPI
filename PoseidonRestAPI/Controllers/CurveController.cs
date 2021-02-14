using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/curvepoint")]
    public class CurveController : Controller
    {
        private readonly ICurvePointService _curvePointService;

        public CurveController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<CurvePoint>> GetAll()
        {
            try
            {
                var result = _curvePointService.FindAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{curvePointId}")]
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

        [HttpPut("{curvePointId}")]
        public void Update(int curvePointId, [FromBody] EditCurvePointDTO curvePoint)
        {
            try
            {
                _curvePointService.Update(curvePointId, curvePoint);
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
                return BadRequest(e);
            }
        }
    }
}