using PoseidonRestAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IJWTTokenRepository
    {
        JwtAccessToken GetJWTTokenById(int userId);
        JwtAccessToken GetJWTToken(JsonWebToken tokenAccess);
        JwtAccessToken GetJWTToken(string tokenAccess);
        void SaveAccessToken(JsonWebToken accessToken, int userId);
        void RemoveAccessToken(int userId);
        void RemoveAccessToken(JwtAccessToken accessToken);
    }
}
