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
        JwtAccessToken GetJWTToken(JwtAccessToken tokenAccess);
        JwtAccessToken GetJWTToken(string token);
        void SaveAccessToken(JwtAccessToken accessToken, int userId);
        void RemoveAccessToken(int userId);
        void RemoveAccessToken(JwtAccessToken accessToken);
    }
}
