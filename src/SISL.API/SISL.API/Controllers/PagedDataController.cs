using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SISL.API.Filters;
using SISL.Core.Constants;
using SISL.Core.Interfaces;

namespace SISL.API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class PagedDataController : RootController
    {
        private readonly ICustomerAccountService _customerAccountRepository;
        private readonly ILogger<PagedDataController> _logger;

        public PagedDataController(ICustomerAccountService customerAccountRepository,
            ILogger<PagedDataController> logger)
        {
            _customerAccountRepository = customerAccountRepository;
            _logger = logger;
        }

        //[Route("GetPendingCustomerAccounts")]
        //[HttpGet]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public async Task<IActionResult> GetPendingCustomerAccounts([FromQuery] PaginationParams @params)
        //{
        //    try
        //    {
        //        var data = await _customerAccountRepository.GetPendingAccountsAsync(@params);
        //        Response.AddPaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        //        return Ok(data);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError($"Exception occured on api/PagedData/sisl/GetPendingCustomerAccounts -> {e.Message}", e);
        //        return BadRequest();
        //    }
        //}

        //[Route("GetApprovedCustomerAccounts")]
        //[HttpGet]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public async Task<IActionResult> GetApprovedCustomerAccounts([FromQuery] PaginationParams @params)
        //{
        //    var data = await _customerAccountRepository.GetApprovedAccountsAsync(@params);
        //    Response.AddPaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        //    return Ok(data);
        //}

        //[Route("GetProcessingCustomerAccounts")]
        //[HttpGet]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public async Task<IActionResult> GetProcessingCustomerAccounts([FromQuery] PaginationParams @params)
        //{
        //    var data = await _customerAccountRepository.GetProcessingAccountsAsync(@params);
        //    Response.AddPaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

        //    return Ok(data);
        //}

        [Route("GetAllCustomerAccounts")]
        [HttpGet]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> GetAllCustomerAccounts([FromQuery] PaginationParams @params)
        {
            try
            {
                var data = await _customerAccountRepository.GetAccountsAsync(@params);
                Response.AddPaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occured on api/PagedData/sisl/GetAllCustomerAccounts -> {e.Message}", e);
            }

            return BadRequest();
        }
    }
}