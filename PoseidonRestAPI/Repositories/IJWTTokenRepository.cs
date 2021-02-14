using PoseidonRestAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonRestAPI.Repositories
{
    public interface IJWTTokenRepository
    {
        JwtAccessToken GetJWTToken(int userId);
        JwtAccessToken CreateAccessToken(int userId);
    }
}
