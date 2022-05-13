using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SISL.Core.Interfaces
{
    public interface ISmileHelper
    {
        Task<(string, HttpStatusCode)> MakeRequestAndGetResponseGeneral(string datastring, string URL, string Method, bool hasHeader,
            string Authorization, string ModuleId, string ContentType, string soapAction, string logPath);
    }
}