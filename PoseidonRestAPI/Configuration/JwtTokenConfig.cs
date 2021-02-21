using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Configuration
{
    public static class JwtTokenConfig
    {
        public const string ValidIssuer = "PoseidonAPP";
        public const string ValidAudience = "PoseidonUser";
        public static string key = "C1CF4B7DC4C4175B6618DE4F55CA4";
        public const int DefaultTokenTimeout = 20;
        public static DateTime Expires = DateTime.Now.AddMinutes(DefaultTokenTimeout);
    }
}
