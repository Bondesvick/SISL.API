using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISL.Core.Responses;

namespace SISL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        public RootController()
        {
        }

        protected ApiResponse<T> ApiResponse<T>(T value)
        {
            return new ApiResponse<T>(value);
        }

        protected ApiResponse<T> ApiResponse<T>(string[] value)
        {
            return new ApiResponse<T>(value);
        }
    }
}