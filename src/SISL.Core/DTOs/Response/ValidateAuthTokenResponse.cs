using System.Diagnostics.CodeAnalysis;
using SISL.Core.Models;

namespace SISL.Core.DTOs.Response
{
    [ExcludeFromCodeCoverage]
    public class ValidateAuthTokenResponse
    {
        public ValidateAuthTokenResponse()
        {
            Head = new ApiResponseHead();
            Body = "";
        }

        public ApiResponseHead Head { get; set; }

        public object Body { get; set; }
    }
}