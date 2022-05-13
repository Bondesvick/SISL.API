using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SISL.API.Filters;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.Interfaces;
using SISL.Core.Services;

namespace SISL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpoolRequestController : RootController
    {
        private readonly ILogger<SpoolRequestController> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerAccountService _customerAccountRepository;

        public SpoolRequestController(ILogger<SpoolRequestController> logger, IMapper mapper, ICustomerAccountService customerAccountRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerAccountRepository = customerAccountRepository;
        }

        [Route("SpoolRequest")]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> SpoolRequest(SpoolDto spoolDto)
        {
            //return Ok();
            try
            {
                var data = await _customerAccountRepository.GetAllTItems();

                var customerAccounts = data.ToList();
                var value = customerAccounts.Where(x =>
                        x.Status == spoolDto?.Status
                        && x.InitiatedDate >= spoolDto?.StartDate && x.InitiatedDate <= spoolDto?.EndDate.AddDays(1));
                //.Take(spoolDto.Count ?? 100);

                if (spoolDto.Status == "All")
                    value = customerAccounts.Where(x => x.InitiatedDate >= spoolDto.StartDate && x.InitiatedDate <= spoolDto.EndDate.AddDays(1));//.Take(spoolDto.Count ?? 50);

                var enumerable = value.ToList();
                if (enumerable.Any())
                {
                    var final = enumerable.Select(x => _mapper.Map<CustomerAccountDto>(x)).ToList();

                    return Ok(new GenericApiResponse<List<CustomerAccountDto>>()
                    {
                        ResponseCode = RESPONSE_CODE.SUCCESS,
                        ResponseDescription = "Success",
                        Data = final
                    });
                }

                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = RESPONSE_DESCRIPTION.NO_DATA_FOUND,
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = RESPONSE_DESCRIPTION.GENERAL_FAILURE,
                });
            }
        }

        //[Route("SpoolApprovedRequest")]
        //[HttpPost]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public IActionResult SpoolApprovedRequest(SpoolDto spoolDto)
        //{
        //    return Ok();
        //}

        //[Route("SpoolProcessingRequest")]
        //[HttpPost]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public IActionResult SpoolProcessingRequest(SpoolDto spoolDto)
        //{
        //    return Ok();
        //}

        //[Route("SpoolAllRequest")]
        //[HttpPost]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public IActionResult SpoolAllRequest(SpoolDto spoolDto)
        //{
        //    return Ok();
        //}
    }
}