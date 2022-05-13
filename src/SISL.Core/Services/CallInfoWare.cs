using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;
using SISL.Core.Extensions;
using SISL.Core.Helpers;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class CallInfoWare : ICallInfoWare
    {
        private readonly ILogger<CallInfoWare> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpRequest _httpRequest;
        private readonly ICustomerAccountService _customerAccountRepository;
        private readonly IMapper _mapper;

        public CallInfoWare(ILogger<CallInfoWare> logger,
            IConfiguration configuration, IHttpRequest httpRequest,
            ICustomerAccountService customerAccountRepository, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _httpRequest = httpRequest;
            _customerAccountRepository = customerAccountRepository;
            _mapper = mapper;
        }

        public async Task<PostCustomerResponse> PostToInfoWare(CustomerAccount account, PostCustomerResponse session)
        {
            try
            {
                string url = _configuration["AppSettings:SaveCustomerUrl"];
                url = url + session.OutValue;

                var values = BuildPostPayload(account);

                var response = await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(values, url);

                if (response == null)
                    return null;

                if (response.StatusId != 0)
                    return response;

                foreach (var document in account.SislDocuments)
                {
                    //document.ContentOrPath.Converting();
                    var uploadResult = await UploadDocument(document, response.OutValue, session);

                    if (uploadResult == null)
                        return null;

                    if (uploadResult.StatusId != 0)
                        return uploadResult;
                }

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public async Task UpdateToInfoWare(CustomerAccount account, string url)
        {
            try
            {
                await BuildAndUpdatePayload(account, url);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        private async Task<PostCustomerResponse> UploadDocument(SislDocument document, string parentId, PostCustomerResponse session)
        {
            try
            {
                string url = _configuration["AppSettings:UploadDocumentUrl"];
                url = url + session.OutValue;

                var values = BuildDocumentUploadPayload(document, parentId);

                var response = await _httpRequest.AsyncPost<PostCustomerResponse>(values, url, document.ContentOrPath, document.ContentOrPath.ConvertBase64ToByte());

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        private Dictionary<string, string> BuildPostPayload(CustomerAccount request)
        {
            var values = new Dictionary<string, string>();
            var @params = $"{request.Title}|{request.SureName.Purge()}|{request.FirstName.Purge()}|{request.OtherNames.Purge()}|{request.DateOfBirth:yyyy-MM-dd}|{(request.Sex == 1 ? "Male" : "Female")}|{request.PermanentAddress.Purge()}|{request.City.Purge()}|{request.Country.Purge()}|{request.State.Purge()}|{request.LGA.Purge()}|{request.EmailAddress.Purge()}|{request.Telephone.Purge()}|{request.Occupation.Purge()}|{request.CompName.Purge()}|{request.EmploymentType.Purge()}|{request.PoliticallyExposed.Purge()}|{request.BankAcctName.Purge()}|{request.BankAccNumber}|{request.BVN}|{request.IdType.Purge()}|{request.IdNumber}|{request.MeansOfIDExpirationDate:dd-MMM-yyyy}|{request.NextOfKin.Purge()}|{request.Relationship.Purge()}|{request.ContactAddress.Purge()}|{request.NextOfKinPhone}|{request.NextOfKinEmail.Purge()}|{request.NextOfKinSurname.Purge()}|{request.NextOfKinOtherNames.Purge()}|{request.MeansOfIDIssueDate:dd-MMM-yyyy}|{request.DateOfOffice:dd-MMM-yyyy}|{request.PositionHeld.Purge()}|{request.PoliticallyExposed.Purge()}|{request.MaritalStatus}|{request.MothersMaidenName.Purge()}|{request.AverageAnnualIncome}|{request.SourceofInvestment}|{request.PurposeofInvestment}|{request.PEPWho.Purge()}/{request.PoliticallyExposedPerson.Purge()}|{request.NextOfKinGender}|{request.NOKDateOfBirth:dd-MMM-yyyy}|{request.NOKNationality.Purge()}";

            values.Add("FunctionID", "P_00120");
            values.Add("Params", @params);

            return values;
        }

        private Dictionary<string, string> BuildDocumentUploadPayload(SislDocument document, string parentId)
        {
            var values = new Dictionary<string, string>();

            values.Add("ParentID", parentId);
            values.Add("FileName", document.FileName);
            values.Add("FileType", document.ContentType);

            return values;
        }

        private async Task BuildAndUpdatePayload(CustomerAccount request, string url)
        {
            var values = new Dictionary<string, string>();

            //values = AddToDictionary("Next Of Kin", request.NextOfKin);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Next Of Kin", request.NextOfKin), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Gender", request.Sex == 1 ? "Male" : "Female"), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Relationship", request.Relationship), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("E-mail", request.EmailAddress), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Phone Number", request.Telephone), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Contact Details", request.PermanentAddress), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Nationality", request.Country), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Date of Birth", request.DateOfBirth.ToString("d")), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Mothers Maiden Name", request.MothersMaidenName), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("PEP", request.PoliticallyExposed), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("State of Origin", request.State), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Occupation", request.Occupation), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("BVN", request.BVN), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("DateOfOffice", request.DateOfOffice?.ToString("d")), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Means of ID Issue Date", request.MeansOfIDIssueDate?.ToString("d")), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Means of ID Expiration Date", request.MeansOfIDExpirationDate?.ToString("d")), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("IdNumber", request.IdNumber), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("LGA", request.LGA), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("PositionHeld", request.PositionHeld), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("PoliticallyExposedPerson", request.PoliticallyExposedPerson + "/" + request.PEPWho), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("AverageAnnualIncome", request.AverageAnnualIncome), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("SourceofInvestment", request.SourceofInvestment), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("PurposeofInvestment", request.PurposeofInvestment), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("PEPWho", request.PoliticallyExposedPerson + "/" + request.PEPWho), url);

            //await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("BankAccountNumber", request.BankAccNumber), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("BankAcctName", request.BankAcctName), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("BankAcctNumber", request.BankAccNumber), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Means of ID", request.IdType), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("EmploymentType", request.EmploymentType), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Next of Kin Gender", request.NextOfKinGender), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Next of Kin Date of Birth", request.NOKDateOfBirth?.ToString("d")), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("NOK Nationality", request.NOKNationality), url);

            await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(AddToDictionary("Risk", request.Risk), url);

            var details = ReflectionConverter.GetPropertyValues(request);

            foreach (var detail in details)
            {
                var name = ReflectionConverter.GetPropertyName(detail);
                var value = ReflectionConverter.GetPropertyValue(request, name);

                switch (name)
                {
                    case nameof(request.NOKNationality):
                        //values = AddToDictionary("NOK Nationality", value?.ToString());
                        //await _httpRequest.GetWithQueryAsync<PostCustomerResponse>(values, url);
                        break;
                }
            }

            //values.Add("ThisIs", "Annoying");
        }

        private Dictionary<string, string> AddToDictionary(string name, string value)
        {
            var values = new Dictionary<string, string>();
            values.Add("AttributeName", name);
            values.Add("AttributeValue", value);
            return values;
        }
    }
}