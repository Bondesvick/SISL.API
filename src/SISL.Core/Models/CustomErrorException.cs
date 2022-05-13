using System;
using SISL.Core.Constants;

namespace SISL.Core.Models
{
    public class CustomErrorException : Exception
    {
        public string StatusCode;

        public CustomErrorException(string message, string statusCode = RESPONSE_CODE.INTERNAL_EXCEPTION) :
            base(message)
        {
            StatusCode = statusCode;
        }
    }
}