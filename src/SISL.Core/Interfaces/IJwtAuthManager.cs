using System;
using System.Security.Claims;

namespace SISL.Core.Interfaces
{
    public interface IJwtAuthManager
    {
        string GenerateAccessToken(string username, Claim[] claims, DateTime now);
    }
}