using Microsoft.AspNetCore.Mvc;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        public IUserService _userService;
        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void CreateToken([FromBody] EditTradeDTO tradeDTO)
        {
            try
            {
                _jWTTokenRepository.SaveAccessToken(tradeDTO);
            }
            catch (Exception)
            {
                // Implement logging MS 
                //throw StatusCode(500, "Internal server error");
            }

        }

    }
}
