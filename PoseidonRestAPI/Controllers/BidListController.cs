using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Repositories;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("bidlist")]
    public class BidListController : Controller
    {

        private IGenericRepository<CurvePoint> _Repository;
        public BidListController(IGenericRepository<CurvePoint> repository)
        {
            _Repository = repository;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                var result = _Repository.GetAll();
                return View(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("/bidList/validate")]
        public IActionResult Validate([FromBody]CurvePoint bidList)
        {
            // TODO: check data valid and save to db, after saving return bid list
            return View("bidList/add");
        }

        [HttpGet("/bidList/update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            return View("bidList/update");
        }

        [HttpPost("/bidList/update/{id}")]
        public IActionResult UpdateBid(int id, [FromBody] CurvePoint bidList)
        {
            // TODO: check required fields, if valid call service to update Bid and return list Bid
            return Redirect("/bidList/list");
        }

        [HttpDelete("/bidList/{id}")]
        public IActionResult DeleteBid(int id)
        {
            return Redirect("/bidList/list");
        }
    }
}