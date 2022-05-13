using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SISL.Core.Interfaces
{
    public interface IHttpRequest
    {
        Task<T> AsyncPost<T>(Dictionary<string, string> values, string url, string base64 = null,
            byte[] byteArray = null);

        Task<T> GetWithQueryAsync<T>(Dictionary<string, string> values, string url);

        Task<T> AsyncGet<T>(string url);
    }
}