using System;
using SISL.Core.Constants;

namespace SISL.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public string Code = RESPONSE_CODE.BAD_REQUEST;
    }
}