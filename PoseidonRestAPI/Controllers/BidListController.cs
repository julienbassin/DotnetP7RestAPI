using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonRestAPI.Domain;
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
            //if (bidList == null)
            //{
            //    return BadRequest("BidList object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Invalid model object");
            //}

            //try
            //{
                
                
                
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500, "Internal server error");
            //}            //if (bidList == null)
            //{
            //    return BadRequest("BidList object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Invalid model object");
            //}

            //try
            //{
                
                
                
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500, "Internal server error");
            //}



            _bidService.Add(bidList);

        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete(int Id)
        {
            _bidService.Delete(Id);
        }
    }
}