using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.Exceptions;
using SISL.Core.Interfaces;
using SISL.Core.Services;
using Microsoft.Extensions.Configuration;

namespace SISL.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityValidationController : ControllerBase
    {
        private readonly IIdValidationService _idValidationService;
        private readonly ILogger<IdentityValidationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRedboxAccountServiceProxy _customerAccountsService;
        private readonly IRedboxNipService _redboxNipService;

        public IdentityValidationController(
                IIdValidationService idValidationService,
                ILogger<IdentityValidationController> logger,
                IConfiguration configuration,
                IRedboxAccountServiceProxy customerAccountsService,
                IRedboxNipService redboxNipService)
        {
            _idValidationService = idValidationService;
            _logger = logger;
            _configuration = configuration;
            _customerAccountsService = customerAccountsService;
            _redboxNipService = redboxNipService;
        }

        [HttpPost]
        [Route("ValidateAccount")]
        public async Task<IActionResult> ValidateAccount([FromBody] AccountDetailsRequest request)
        {
            try
            {
                var (status, value, description) = await _redboxNipService.ValidateAccount(request);

                //var accountEnquiry = await _customerAccountsService.DoAccountCIFEnquiry(request.AccountNumber);

                if (!status)
                {
                    return Ok(new GenericApiResponse<object>()
                    {
                        ResponseCode = RESPONSE_CODE.FAILURE,
                        ResponseDescription = $"{description} - Failed to fetch customer account for {request.AccountNumber} at this time. Make sure the account number entered is correct"
                    });
                }

                var result = new GenericApiResponse<string>
                {
                    ResponseCode = "00",
                    ResponseDescription = description,
                    Data = value
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occured on api/IdentityValidation/sisl/Validate -> {e.Message}", e);

                return Ok(new GenericApiResponse<object>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = "Something went wrong"
                });
            }
        }

        [HttpPost("Validate")]
        [ProducesResponseType(200, Type = typeof(GenericApiResponse<ValidationModel>))]
        public async Task<ActionResult<VerifyIdResponseDto>> Validate(ValidationModel identityRequestBody)
        {
            try
            {
                var (data, error) = await _idValidationService.Validate(identityRequestBody);

                if (data != null)
                {
                    return Ok(new GenericApiResponse<VerifyIdResponseDto>()
                    {
                        ResponseCode = RESPONSE_CODE.SUCCESS,
                        ResponseDescription = "Success",
                        Data = data
                    });
                }

                return Ok(new GenericApiResponse<object>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = error
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occured on api/IdentityValidation/sisl/Validate -> {e.Message}", e);

                return Ok(new GenericApiResponse<object>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = "Something went wrong"
                });
            }
        }

        //[HttpPost("")]
        //public async Task<ActionResult<ValidateIdentityResponseDTO>> ValidateIdentity(ValidateIdentityRequestDto identityRequestBody)
        //{
        //    try
        //    {
        //        var response = await _idValidationService.ValidateIdentity(identityRequestBody);

        //        return Ok(new GenericApiResponse<ValidateIdentityResponseDTO>()
        //        {
        //            ResponseCode = RESPONSE_CODE.SUCCESS,
        //            ResponseDescription = "Success",
        //            Data = response
        //        });
        //    }
        //    catch (BadRequestException ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        return Ok(new GenericApiResponse<object>()
        //        {
        //            ResponseCode = RESPONSE_CODE.SUCCESS,
        //            ResponseDescription = ex.Message
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);

        //        return Ok(new GenericApiResponse<object>()
        //        {
        //            ResponseCode = RESPONSE_CODE.FAILURE,
        //            ResponseDescription = "Something went wrong"
        //        });
        //    }
        //}
    }
}