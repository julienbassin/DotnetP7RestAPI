using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Domain;
using PoseidonRestAPI.Resources;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    [Route("api/rule")]
    public class RuleNameController : Controller
    {
        private readonly IRuleService _ruleService;

        public RuleNameController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Rule>> GetAll()
        {
            try
            {
                var result = _ruleService.FindAll();
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("{ruleId}")]
        public IActionResult FindById(int ruleId)
        {
            try
            {
                var result = _ruleService.FindById(ruleId);
                return Ok(new JsonResult(result));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public void Create([FromBody] EditRuleDTO editRuleDTO)
        {
            try
            {
                _ruleService.Add(editRuleDTO);
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{ruleId}")]
        public void Update(int ruleId, [FromBody] EditRuleDTO ruleDTO)
        {
            try
            {
                
                _ruleService.Update(ruleId, ruleDTO);
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
                var curvePoint = _ruleService.FindById(Id);
                if (curvePoint == null)
                {
                    return NotFound();
                }
                _ruleService.Delete(Id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}