using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/trade")]
    public class TradeController : Controller
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Trade>> GetAll()
        {
            try
            {
                var result = _tradeService.FindAll();
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
                var result = _tradeService.FindById(tradeId);
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
                var result = _tradeService.ValidateResource(tradeDTO);
                if (!result.IsValid)
                {

                }

                if (result.IsValid)
                {
                    _tradeService.Add(tradeDTO);
                }
                
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{tradeId}")]
        public void Update(int tradeId, [FromBody] EditTradeDTO tradeDTO)
        {
            try
            {
                _tradeService.Update(tradeId, tradeDTO);
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
                var curvePoint = _tradeService.FindById(Id);
                if (curvePoint == null)
                {
                    return NotFound();
                }
                _tradeService.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}