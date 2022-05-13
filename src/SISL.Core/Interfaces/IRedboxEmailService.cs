using System.Threading.Tasks;
using SISL.Core.DTOs.Request.Redox;

namespace SISL.Core.Interfaces
{
    public interface IRedboxEmailService
    {
        Task<BaseRedboxResponse> SendEmailAsync(RedboxEmailMessageModel mailMessage);
    }
}