using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SISL.API.Filters;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;
using SISL.Core.Interfaces;

namespace SISL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : RootController
    {
        private readonly ILogger<ProcessController> _logger;
        private readonly ICustomerAccountService _customerAccountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private SislHistory history;

        public ProcessController(
            ILogger<ProcessController> logger,
            ICustomerAccountService customerAccountRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _logger = logger;
            _customerAccountRepository = customerAccountRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [Route("SaveCustomerAccount")]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> SaveCustomerAccount(SaveCustomerAccountDto customerAccountDto)
        {
            try
            {
                var account = _mapper.Map<CustomerAccount>(customerAccountDto);
                //account.SessionId = Guid.NewGuid().ToString();

                history = new SislHistory
                {
                    CustomerAccount = account,
                    CommentDate = DateTime.Now,
                    CommentBy = customerAccountDto.InitiatedBy,
                    Comment = "New Request",
                    LastUpdatedBy = customerAccountDto.LastUpdatedBy,

                    SislStatus = new SislStatus
                    {
                        SislHistory = history,
                        status = "Pending"
                    }
                };

                account.SislHistories.Add(history);
                account.Status = "Pending";
                account.InitiatedDate = DateTime.Now;

                account.SislDocuments = BuildExtraAccountDocsFromPayload(customerAccountDto);

                if (!string.IsNullOrEmpty(customerAccountDto.CustAid) || customerAccountDto.Id != null)
                {
                    var accounts = await _customerAccountRepository.GetAllTItems();

                    var existing = accounts.FirstOrDefault(x =>
                                                x.CustAid == customerAccountDto.CustAid || x.Id == customerAccountDto?.Id);
                    if (existing != null)
                    {
                        customerAccountDto.Id = existing.Id;
                        var toUpdate = _mapper.Map(customerAccountDto, existing);
                        await _customerAccountRepository.Update(existing);
                    }
                    else
                    {
                        await _customerAccountRepository.Add(account);
                    }
                }
                else
                {
                    await _customerAccountRepository.Add(account);
                }

                string message = _configuration["AppSettings:EmailMessage"];
                message = message.Replace("#name", customerAccountDto.InitiatedBy);
                await _customerAccountRepository.SendNotificationEmailAsync(customerAccountDto.InitiatorEmail, message);

                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = RESPONSE_DESCRIPTION.REQUEST_SAVED,
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occurred on api/Process/sisl/SaveCustomerAccount -> {e.Message}", e);
                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = RESPONSE_DESCRIPTION.ERROR,
                });
            }
        }

        [Route("GetCustomerAccountById")]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        [ProducesResponseType(200, Type = typeof(GenericApiResponse<CustomerAccountDto>))]
        public async Task<IActionResult> GetCustomerAccountById(AccountRequestParamsDto requestParams)
        {
            try
            {
                var account = await _customerAccountRepository.GetById(requestParams.Id);

                if (account == null)
                    return Ok(new GenericApiResponse<string>()
                    {
                        ResponseCode = RESPONSE_CODE.FAILURE,
                        ResponseDescription = RESPONSE_DESCRIPTION.NO_DATA_FOUND,
                    });

                var toReturn = _mapper.Map<CustomerAccountDto>(account);

                return Ok(new GenericApiResponse<CustomerAccountDto>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "Success",
                    Data = toReturn
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occurred on api/Process/sisl/GetCustomerAccountById -> {e.Message}", e);
                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = e.Message,
                });
            }
        }

        [Route("GetCustomerAccountSummaryById")]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        [ProducesResponseType(200, Type = typeof(GenericApiResponse<CustomerAccountDto>))]
        public async Task<IActionResult> GetCustomerAccountSummaryById(AccountRequestParamsDto requestParams)
        {
            try
            {
                var account = await _customerAccountRepository.GetCustomerAccountSummaryById(requestParams.Id);

                var toReturn = _mapper.Map<CustomerAccountDto>(account);

                return Ok(new GenericApiResponse<CustomerAccountDto>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "Success",
                    Data = toReturn
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occurred on api/Process/sisl/GetCustomerAccountSummaryById -> {e.Message}", e);
                return Ok(new GenericApiResponse<string>()
                {
                    ResponseCode = RESPONSE_CODE.FAILURE,
                    ResponseDescription = e.Message,
                });
            }
        }

        //[Route("GetAllCustomerAccounts")]
        //[HttpPost]
        //[ServiceFilter(typeof(ModelStateValidationFilter))]
        //public IActionResult GetAllCustomerAccounts()
        //{
        //    return Ok();
        //}

        [Route("SaveHistory")]
        [HttpPost]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> SaveHistory(SaveSislHistoryDto request)
        {
            try
            {
                var customer = await _customerAccountRepository.GetById(request.CustomerAccountId);
                //history = _mapper.Map<SislHistory>(request);

                history = new SislHistory
                {
                    CustomerAccount = customer,
                    Comment = request.Comment,
                    CommentBy = request.CommentBy,
                    CommentDate = DateTime.Now,
                    LastUpdatedBy = request.LastUpdatedBy,

                    SislStatus = new SislStatus
                    {
                        SislHistory = history,
                        status = request.Status
                    }
                };

                //history.CommentDate = DateTime.Now;
                if (!string.IsNullOrEmpty(request.Risk))
                    customer.Risk = request.Risk;

                customer.SislHistories.Add(history);
                customer.Status = request.AccountStatus;
                customer.Risk = request.Risk ?? "";
                customer.LastUpdatedBy = request.LastUpdatedBy;
                customer.ReasonForRework = request.ReasonForRework ?? "";

                await _customerAccountRepository.Update(customer);

                string message = _configuration["AppSettings:EmailMessage"];
                message = message.Replace("#name", request.CommentBy);
                await _customerAccountRepository.SendNotificationEmailAsync(request.Email, message);

                return Ok(new GenericApiResponse<object>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "Success",
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception occurred on api/Process/sisl/SaveHistory -> {e.Message}", e);
                return Ok(new GenericApiResponse<object>()
                {
                    ResponseCode = RESPONSE_CODE.SUCCESS,
                    ResponseDescription = "An Error occurred",
                });
            }
        }

        private IList<SislDocument> BuildExtraAccountDocsFromPayload(SaveCustomerAccountDto request)
        {
            return request.Documents?.Select(doc => new SislDocument { FileName = doc.Name, Title = doc.Title, ContentOrPath = doc.Base64Content, ContentType = GetDocumentContentType(doc.Name) }).ToList();
        }

        private string GetDocumentContentType(string fileName)
        {
            string contenttype = "";
            switch (fileName.Split('.')[1].ToLower())
            {
                case "doc":
                    contenttype = "application/vnd.ms-word";
                    break;

                case "docx":
                    contenttype = "application/vnd.ms-word";
                    break;

                case "pdf":
                    contenttype = "application/pdf";
                    break;

                case "jpg":
                    contenttype = "image/jpeg";
                    break;

                case "svg":
                    contenttype = "image/svg+xml";
                    break;

                case "jpeg":
                    contenttype = "image/jpeg";
                    break;

                case "png":
                    contenttype = "image/png";
                    break;

                case "gif":
                    contenttype = "image/gif";
                    break;
            }
            return contenttype;
        }
    }
}