using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.ModelValidator;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/bidlist")]
    public class BidListController : Controller
    {
        private readonly IBidListService _bidService;
        public BidListController(IBidListService bidService)
        {
            _bidService = bidService;            
        }


        [HttpGet()]
        public ActionResult <IEnumerable<BidList>> GetAll()
        {
            try
            {
                var result = _bidService.FindAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{bidlistId}")]
        public IActionResult FindById(int bidListId)
        {
            try
            {
                var result = _bidService.FindById(bidListId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditBidListDTO bidList)
        {
            
            try
            {
                var result = _bidService.ValidateResource(bidList);
                if (!result.IsValid)
                {
                        
                }

                if (result.IsValid)
                {
                    _bidService.Add(bidList);
                }
                
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{bidlistId}")]
        public IActionResult Update(int bidlistId, [FromBody] EditBidListDTO editBidListDTO)
        {
            try
            {
                _bidService.Update(bidlistId, editBidListDTO);
                return Ok();
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

            return ValidationProblem();
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            _bidService.Delete(Id);
            return Ok();
        }
    }
}