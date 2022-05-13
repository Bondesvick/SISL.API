using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;

namespace SISL.Core.Interfaces
{
    public interface ICustomerAccountService
    {
        Task Add(CustomerAccount entity);

        Task Update(CustomerAccount entity);

        Task<CustomerAccount> GetById(long id);

        Task<CustomerAccount> GetCustomerAccountSummaryById(long id);

        Task<IEnumerable<CustomerAccount>> GetAllTItems();

        //Task<PagedList<CustomerAccountDto>> GetPendingAccountsAsync(PaginationParams @params);

        //Task<PagedList<CustomerAccountDto>> GetApprovedAccountsAsync(PaginationParams @params);

        //Task<PagedList<CustomerAccountDto>> GetProcessingAccountsAsync(PaginationParams @params);

        Task<PagedList<CustomerAccountDto>> GetAccountsAsync(PaginationParams @params);

        Task SendNotificationEmailAsync(string emailAddress, string message);
    }
}