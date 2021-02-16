using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        public IJWTTokenRepository _jWTTokenRepository;
        public TokenController(IJWTTokenRepository jWTTokenRepository)
        {
            _jWTTokenRepository = jWTTokenRepository;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Trade>> GetAll()
        {
            try
            {
                var result = _jWTTokenRepository.FindAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{tradeId}")]
        public IActionResult FindById(int tradeId)
        {
            try
            {
                var result = _jWTTokenRepository.FindById(tradeId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditTradeDTO tradeDTO)
        {
            try
            {
                _jWTTokenRepository.Add(tradeDTO);
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
                var curvePoint = _jWTTokenRepository.FindById(Id);
                if (curvePoint == null)
                {
                    return NotFound();
                }
                _jWTTokenRepository.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
