using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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

    // JsonWebToken DTO 
    public class JsonWebToken
    {
        public string Token { get; set; }
        public string Type { get; set; } = "Bearer";
        public int Expires { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; }

        // method to create password hash
        public static void CreatePasswordHash(string password,
                                       out byte[] passwordHash,
                                       out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash
                        (System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // method to handle verifyhash token  

        public bool VerifyPasswordHash(string password,
                                       byte[] passwordHash,
                                       byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash
                    (System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public JsonWebToken GenerateWebToken(int userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,
                        userId.ToString()),
                new Claim(ClaimTypes.Name, "data")
            };
            var tokenSecretKey = Encoding.UTF8.GetBytes(
                              JwtTokenConfig.key);
            var key = new SymmetricSecurityKey(tokenSecretKey);
            var credentials = new SigningCredentials(key,
                               SecurityAlgorithms.HmacSha512Signature);
            
            var token = new JwtSecurityToken
            (                
                JwtTokenConfig.ValidIssuer,
                JwtTokenConfig.ValidAudience,
                claims,
                expires: JwtTokenConfig.Expires,
                signingCredentials: credentials);

            var accessToken = new JsonWebToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = JwtTokenConfig.DefaultTokenTimeout,
                ExpiresAt = JwtTokenConfig.Expires,
                Type = "Bearer"
            };
            
            return accessToken;
        }
    }

    
}
