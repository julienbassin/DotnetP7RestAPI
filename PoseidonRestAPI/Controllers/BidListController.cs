using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/bidlist")]
    public class BidListController : Controller
    {

        private readonly IBidListRepository _bidListRepository;
        public BidListController(IBidListRepository bidListRepository)
        {
            _bidListRepository = bidListRepository ??
                throw new ArgumentException(nameof(bidListRepository));
        }


        [HttpGet()]
        public ActionResult <IEnumerable<BidList>> GetAll()
        {
            try
            {
                var result = _bidListRepository.GetAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{bidlistId}")]
        public IActionResult FindBidlistById(int bidListId)
        {
            try
            {
                var result = _bidListRepository.FindById(bidListId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void AddBidList([FromBody] BidList bidList)
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

            _bidListRepository.Insert(bidList);

        }

        [HttpDelete]
        [Route("{Id}")]
        [AllowAnonymous]
        public void DeleteBidList(int Id)
        {
            _bidListRepository.Delete(Id);
        }
    }
}