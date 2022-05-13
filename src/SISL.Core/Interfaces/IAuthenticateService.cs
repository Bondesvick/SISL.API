using System.Threading.Tasks;
using QuickServiceAdmin.Core.Model;

namespace SISL.Core.Interfaces
{
    public interface IAuthenticateService
    {
        Task<TokenGenerationResponse> GenerateToken(string userId, string jwtToken);

        Task<string> ValidateAuthenticationToken(string userId, string jwtToken);
    }
}