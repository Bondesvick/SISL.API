using System.Threading.Tasks;
using SISL.Core.DTOs.Request.Redox;

namespace SISL.Core.Interfaces
{
    public interface IRedboxRequestManagerProxy
    {
        Task<BaseRequestManagerResponse<T2>> Post<T2>(string xmlReq, string module = "1", string authId = "1") where T2 : class;
    }
}