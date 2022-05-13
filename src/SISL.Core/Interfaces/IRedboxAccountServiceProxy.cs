using System.Collections.Generic;
using System.Threading.Tasks;
using QSDataUpdateAPI.Domain.Models.Response.Redbox;

namespace SISL.Core.Interfaces
{
    public interface IRedboxAccountServiceProxy
    {
        Task<(string responseCode, string responseDescription, AccountEnquiryInfo result)> DoAccountCIFEnquiry(string accountNumber);
    }
}