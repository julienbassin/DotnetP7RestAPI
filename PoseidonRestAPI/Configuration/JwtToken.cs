using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Configuration
{
    public class JwtAccessToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string JWTToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ExpiresAt { get; set; }
    }
}
