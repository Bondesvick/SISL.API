using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Request.Redox;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly IRepository<CustomerAccount> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerAccountService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _configSettings;
        private readonly IAppLogger _appLogger;
        private readonly IRedboxEmailService _emailService;

        public CustomerAccountService(
            IRepository<CustomerAccount> repository,
            IMapper mapper,
            ILogger<CustomerAccountService> logger,
            IConfiguration configuration,
            IAppSettings configSettings,
            IAppLogger appLogger,
            IRedboxEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _configSettings = configSettings;
            _appLogger = appLogger;
            _emailService = emailService;
        }

        public async Task Add(CustomerAccount entity)
        {
            try
            {
                _logger.LogInformation("Saving Customer Details to database");

                await _repository.Add(entity);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while saving Customer account -> {e.Message}", e);
                throw;
            }
        }

        public async Task Update(CustomerAccount entity)
        {
            try
            {
                _logger.LogInformation("Updating Customer Details to database");

                await _repository.Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while updating Customer account -> {e.Message}", e);
                throw;
            }
        }

        public async Task<CustomerAccount> GetById(long id)
        {
            try
            {
                _logger.LogInformation("Get Customer details from database");

                var query = _repository.IncludeQuery(new[] { "SislDocuments", "SislHistories.SislStatus", "SislDocuments" });
                var data = await query.FirstOrDefaultAsync(x => x.Id == id);

                // return await _repository.GetById(id);
                return data;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while fetching Customer account by Id -> {e.Message}", e);
                throw;
            }
        }

        public async Task<CustomerAccount> GetCustomerAccountSummaryById(long id)
        {
            try
            {
                _logger.LogInformation("Get Customer details summary from database");

                var query = _repository.IncludeQuery(new[] { "SislHistories", "SislHistories.SislStatus", "SislDocuments" });

                //query = query.Include(x => x.SislHistories).ThenInclude(x => x.SislStatus);

                var data = await query.FirstOrDefaultAsync(x => x.Id == id);

                return data;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while fetching Customer account summary by Id -> {e.Message}", e);
                return default;
            }
        }

        public Task<IEnumerable<CustomerAccount>> GetAllTItems()
        {
            try
            {
                _logger.LogInformation("Get all Customers from database");

                return _repository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while fetching all Customer account -> {e.Message}", e);
                //return default;
                throw;
            }
        }

        //public async Task<PagedList<CustomerAccountDto>> GetPendingAccountsAsync(PaginationParams @params)
        //{
        //    try
        //    {
        //        var query = _repository.IncludeQuery(new[] { "SislHistories" });
        //        //query = query.Include(x => x.SislHistories).ThenInclude(x => x.SislStatus);

        //        query = query.Where(x => x.Status == "Pending");

        //        var tableData = query.Select(x => _mapper.Map<CustomerAccountDto>(x));

        //        var accounts = await PagedList<CustomerAccountDto>.CreateAsync(tableData, @params.PageNumber, @params.PageSize);

        //        return accounts;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, e.Message);
        //        throw;
        //    }
        //}

        //public async Task<PagedList<CustomerAccountDto>> GetApprovedAccountsAsync(PaginationParams @params)
        //{
        //    try
        //    {
        //        var query = _repository.IncludeQuery(new[] { "SislHistories", "SislHistories.SislStatus" });
        //        query = query.Where(x => x.Status == "Approved");

        //        var tableData = query.Select(x => _mapper.Map<CustomerAccountDto>(x));

        //        var accounts = await PagedList<CustomerAccountDto>.CreateAsync(tableData, @params.PageNumber, @params.PageSize);

        //        return accounts;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, e.Message);
        //        throw;
        //    }
        //}

        //public async Task<PagedList<CustomerAccountDto>> GetProcessingAccountsAsync(PaginationParams @params)
        //{
        //    var query = _repository.IncludeQuery(new[] { "SislHistories", "SislHistories.SislStatus" });
        //    query = query.Where(x => x.Status == "Processing");

        //    var tableData = query.Select(x => _mapper.Map<CustomerAccountDto>(x));

        //    var accounts = await PagedList<CustomerAccountDto>.CreateAsync(tableData, @params.PageNumber, @params.PageSize);

        //    return accounts;
        //}

        public async Task<PagedList<CustomerAccountDto>> GetAccountsAsync(PaginationParams @params)
        {
            try
            {
                _logger.LogInformation("Get all Customers from database");

                var query = _repository.IncludeQuery(new[] { "SislHistories", "SislHistories.SislStatus" });

                if (@params.Filter != "All")
                    query = query.Where(x => x.Status == @params.Filter);

                query = query.OrderByDescending(x => x.InitiatedDate);

                var tableData = query.Select(x => _mapper.Map<CustomerAccountDto>(x));

                var accounts = await PagedList<CustomerAccountDto>.CreateAsync(tableData, @params.PageNumber, @params.PageSize);

                return accounts;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while fetching paged Customer accounts -> {e.Message}", e);
                throw;
            }
        }

        public async Task SendNotificationEmailAsync(string emailAddress, string message)
        {
            var mailMessage = ComposeEmailMessage(emailAddress, message);
            var emailResponse = await _emailService.SendEmailAsync(mailMessage);

            _appLogger.Info($"Email Response for {emailAddress} -> {emailResponse}");
        }

        private RedboxEmailMessageModel ComposeEmailMessage(string email, string message)
        {
            var fromAddress = _configSettings.GetString("AppSettings:SenderEmail");
            var subject = _configSettings.GetString("AppSettings:EmailSubject");

            return new RedboxEmailMessageModel
            {
                FromAddress = fromAddress,
                ToAddress = email,
                Subject = subject,
                MailBody = message
            };
        }
    }
}