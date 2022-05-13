using System.Threading.Tasks;
using SISL.Core.DTOs.Request.Redox;

namespace SISL.Core.Interfaces
{
    public interface ISoapRequestHelper
    {
        Task<BaseRedboxResponse> SoapCall(string soapRequest, string soapAction, string url, string moduleId = "", string authId = "", string contenttype = "text/xml");
    }
}