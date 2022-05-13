using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;

namespace SISL.Core.Interfaces
{
    public interface ICallInfoWare
    {
        Task<PostCustomerResponse> PostToInfoWare(CustomerAccount account, PostCustomerResponse session);

        Task UpdateToInfoWare(CustomerAccount account, string url);
    }
}