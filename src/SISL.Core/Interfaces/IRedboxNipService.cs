using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SISL.Core.DTOs.Request;

namespace SISL.Core.Interfaces
{
    public interface IRedboxNipService
    {
        Task<(bool scuccess, string value, string description)> ValidateAccount(AccountDetailsRequest request);
    }
}