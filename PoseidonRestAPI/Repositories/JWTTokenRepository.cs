using PoseidonRestAPI.Configuration;
using PoseidonRestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public class JWTTokenRepository : IJWTTokenRepository
    {
        private LocalDbContext _localDBContext;
        public JWTTokenRepository(LocalDbContext context)
        {
            _localDBContext = context;
        }

        // get access token by id
        public JwtAccessToken GetJWTTokenById(int userId)
        {
            return _localDBContext.AccessTokens.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public JwtAccessToken GetJWTToken(JsonWebToken tokenAccess)
        {
            return GetJWTToken(tokenAccess.Token);
        }


        public JwtAccessToken GetJWTToken(string tokenAccess)
        {
            return _localDBContext.AccessTokens.Where(x => x.JWTToken == tokenAccess).FirstOrDefault();
        }

        public void SaveAccessToken(JsonWebToken accessToken, int userId)
        {
            // create new token then add it!
            var newToken = new JwtAccessToken
            {
                JWTToken = accessToken.Token,
                UserId = userId,
                ExpiresAt = accessToken.ExpiresAt
            };
            _localDBContext.AccessTokens.Add(newToken);
            _localDBContext.SaveChanges();
        }


        // remove access token
        public void RemoveAccessToken(int userId)
        {
            if (userId > 0)
            {
                var token = _localDBContext.AccessTokens.Where(x => x.UserId == userId).FirstOrDefault();
                RemoveAccessToken(token);
            }
        }

        public void RemoveAccessToken(JwtAccessToken accessToken)
        {
            if (accessToken != null)
            {
                _localDBContext.AccessTokens.Remove(accessToken);
                _localDBContext.SaveChanges();
            }
        }
    }
}
