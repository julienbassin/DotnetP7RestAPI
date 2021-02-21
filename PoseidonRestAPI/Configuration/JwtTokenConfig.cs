using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Configuration
{
    public static class JwtTokenConfig
    {
        public const string ValidIssuer = "P7APP";
        public const string ValidAudience = "P7User";
        public static TimeSpan SkewTime = TimeSpan.Zero;
        public static string key = "C1CF4B7DC4C4175B6618DE4F55CA4";
        public const int DefaultTokenTimeout = 20;
        public static DateTime Expires = DateTime.Now.AddMinutes(DefaultTokenTimeout);

        public static SymmetricSecurityKey GenerateKey()
        {
            byte[] key = Encoding.UTF8.GetBytes(JwtTokenConfig.key);
            var result = new SymmetricSecurityKey(key);
            return result;
        }
    }

    
}
