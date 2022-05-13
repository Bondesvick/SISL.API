using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QuickType;
using SISL.API.Constants;
using SISL.Core.Constants;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;
using SISL.Core.Helpers;
using SISL.Core.Interfaces;

namespace SISL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ILogger<CustomerDetailsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpRequest _httpRequest;
        private readonly ICustomerAccountService _customerAccountRepository;
        private readonly IMapper _mapper;
        private readonly ICallInfoWare _callInfoWare;
        private SislHistory _history;

        public CustomerDetailsController(ILogger<CustomerDetailsController> logger,
            IConfiguration configuration, IHttpRequest httpRequest,
            ICustomerAccountService customerAccountRepository, IMapper mapper, ICallInfoWare callInfoWare)
        {
            _logger = logger;
            _configuration = configuration;
            _httpRequest = httpRequest;
            _customerAccountRepository = customerAccountRepository;
            _mapper = mapper;
            _callInfoWare = callInfoWare;
        }

        [HttpPost]
        [Route("SaveCustomer")]
        [ProducesResponseType(200, Type = typeof(GenericApiResponse<PostCustomerResponse>))]
        public async Task<IActionResult> PostCustomer(SaveSislHistoryDto request)
        {
            try
            {
                var customer = await _customerAccountRepository.GetById(request.CustomerAccountId);
                //var customer = await _customerAccountRepository.GetById(25);
                //var history = _mapper.Map<SislHistory>(request);

                _history = new SislHistory
                {
                    CustomerAccount = customer,
                    Comment = request.Comment,
                    CommentDate = DateTime.Now,
                    CommentBy = request.CommentBy,
                    LastUpdatedBy = request.LastUpdatedBy,

                    SislStatus = new SislStatus
                    {
                        SislHistory = _history,
                        status = request.Status
                    }
                };

                //var content = new FormUrlEncodedContent(values);
                //var values = BuildPayload(customer);

                string sessionUrl = _configuration["AppSettings:SessionIdUrl"];
                var session = await _httpRequest.AsyncGet<PostCustomerResponse>(sessionUrl);

                if (session == null)
                    return Ok(new GenericApiResponse<PostCustomerResponse>() { ResponseCode = RESPONSE_CODE.FAILURE, ResponseDescription = "Failed to fetch session Id", });

                if (!customer.IsNewRequest)
                {
                    //values = BuildUpdatePayload(customer);
                    var updateUrl = _configuration["AppSettings:UpdateCustomerUrl"] + session.OutValue + "/" + customer.CustAid;
                    await _callInfoWare.UpdateToInfoWare(customer, updateUrl);
                }
                else
                {
                    var response = await _callInfoWare.PostToInfoWare(customer, session);

                    if (response == null)
                    {
                        return Ok(new GenericApiResponse<PostCustomerResponse>()
                        {
                            ResponseCode = RESPONSE_CODE.FAILURE,
                            ResponseDescription = "An Error occurred",
                        });
                    }

                    if (response.StatusId != 0)
                    {
                        return Ok(new GenericApiResponse<PostCustomerResponse>()
                        {
                            ResponseCode = RESPONSE_CODE.FAILURE,
                            ResponseDescription = "An Error occurred -- " + response.StatusMessage,
                        });
                    }
                }

                //customer.CustAid = response.OutValue;
                customer.SislHistories.Add(_history);
                customer.Status = request.AccountStatus;
                customer.ApprovedDate = DateTime.Now;
                customer.ApprovedBy = request.ApprovedBy;
                customer.ApproverIp = request.ApproverIp;
                customer.LastUpdatedBy = request.LastUpdatedBy;
                await _customerAccountRepository.Update(customer);

                string message = _configuration["AppSettings:EmailMessage"];
                message = message.Replace("#name", request.ApprovedBy);
                await _customerAccountRepository.SendNotificationEmailAsync(request.Email, message);

                return Ok(new GenericApiResponse<PostCustomerResponse>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "Success",
                    //Data = response
                });
                //}
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occured on api/CustomerDetails/sisl/SaveCustomer -> {e.Message}", e.ToString());

                return Ok(new GenericApiResponse<FetchSessionId>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = "An Error occurred",
                });
            }
        }

        [HttpGet]
        [Route("FetchCustomer/{custId}")]
        [ProducesResponseType(200, Type = typeof(GenericApiResponse<FetchCustomer>))]
        public async Task<IActionResult> FetchCustomer(string custId)
        {
            try
            {
                string sessionUrl = _configuration["AppSettings:SessionIdUrl"];
                var session = await _httpRequest.AsyncGet<FetchSessionId>(sessionUrl);
                if (session == null)
                    return Ok(new GenericApiResponse<FetchSessionId>() { ResponseCode = RESPONSE_CODE.FAILURE, ResponseDescription = "Failed to fetch session Id", });

                string url = _configuration["AppSettings:FetchCustomerUrl"];

                url = url + session.OutValue;

                var values = BuildFetchParams(custId);

                var data = await _httpRequest.GetWithQueryAsync<FetchCustomer>(values, url);

                return Ok(new GenericApiResponse<FetchCustomer>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "Success",
                    Data = data
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occured on api/CustomerDetails/sisl/FetchCustomer -> {e.Message}", e.ToString());
                return Ok(new GenericApiResponse<FetchSessionId>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = "An Error occurred",
                });
            }
        }

        private Dictionary<string, string> BuildFetchParams(string customerId)
        {
            var values = new Dictionary<string, string>();
            //values.Add("ThisIs", "Annoying");
            values.Add("FunctionID", "SISB_00009");
            values.Add("Params", customerId);

            return values;
        }
    }
}