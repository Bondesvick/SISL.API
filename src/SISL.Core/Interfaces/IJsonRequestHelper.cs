using System.Net.Http;
using System.Threading.Tasks;

namespace SISL.Core.Interfaces
{
    public interface IJsonRequestHelper
    {
        Task<string> MakeJsonRequest(string method, string requestUri, HttpClient httpClient,
            StringContent request);
    }
}