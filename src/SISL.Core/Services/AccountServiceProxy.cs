using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QSDataUpdateAPI.Domain.Models.Response.Redbox;
using SISL.Core.Commons;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class AccountServiceProxy : IRedboxAccountServiceProxy
    {
        private readonly IAppLogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IRedboxRequestManagerProxy _requestManagerProxy;

        public AccountServiceProxy(IConfiguration configuration, IAppLogger logger, IRedboxRequestManagerProxy requestManagerProxy)
        {
            _logger = logger;
            _requestManagerProxy = requestManagerProxy;
            _configuration = configuration;
        }

        public async Task<(string responseCode, string responseDescription, AccountEnquiryInfo result)> DoAccountCIFEnquiry(string accountNumber)
        {
            try
            {
                var fetchCustomerAccountInfoPayload = FormAccountCifEnquiryRequestPayload(accountNumber);
                var response = await _requestManagerProxy.Post<string>(fetchCustomerAccountInfoPayload);
                if (response.ResponseCode == "00" || response.ResponseCode == "000" || response.ResponseCode == "202")
                {
                    return ("00", response.ResponseDescription, BuildAccountEnquiryInfoFromResponse(response.Detail));
                }
                return (response.ResponseCode, response.ResponseDescription, null);
            }
            catch (Exception exception)
            {
                _logger.Error("Exception occured while doing corporate account name enquiry", ex: exception);
                throw;
            }
        }

        private AccountEnquiryInfo BuildAccountEnquiryInfoFromResponse(string detail)
        {
            //var mainData = Deserailizer.DeserializeXML<DoCustomerInformationEnquiryResponse>(detail.Replace("ns2:", "").Replace("xmlns:ns2=\"http://soap.finacle.redbox.stanbic.com/\"", ""));
            AccountEnquiryInfo accountEnquiryInfo = new AccountEnquiryInfo
            {
                FirstName = Util.GetFirstTagValue(detail, "FirstName", ignoreCase: false),
                LastName = Util.GetFirstTagValue(detail, "LastName", ignoreCase: false),
                EmailAddress = Util.GetFirstTagValue(detail, "Email", ignoreCase: false),
                PhoneNumber = Util.GetTagValue(detail, "PhoneNumber1"),
                PhoneNumber1 = Util.GetTagValue(detail, "PhoneNumber2"),
                AccountName = Util.GetTagValue(detail, "AccountName"),
                AccountSchemeCode = Util.GetTagValue(detail, "AccountSchemeCode"),
                AccountSchemeType = Util.GetTagValue(detail, "AccountSchemeType"),
                BVN = Util.GetTagValue(detail, "Bvn").Length <= 11 ? Util.GetTagValue(detail, "Bvn") : Util.GetTagValue(detail, "Bvn").Substring(0, 11),
                CustomerCreationDate = Util.GetTagValue(detail, "AccountOpenDate"),
                AccountStatus = Util.GetTagValue(detail, "AccountStatus"),
                CustomerId = Util.GetTagValue(detail, "CustId"),
            };
            var firstTag = Util.GetFirstTagValue(detail, "PhoneEmailType");
            var secondTag = Util.GetSecondTagValue(detail, "PhoneEmailType");
            var thirdTag = Util.GetThirdTagValue(detail, "PhoneEmailType");
            if (firstTag == "HOMEEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetFirstTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "HOMEEML";
            }
            else if (firstTag == "COMMEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetFirstTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "COMMEML";
            }
            else if (firstTag == "CELLPH")
            {
                accountEnquiryInfo.phoneEmailIdPhone = Util.GetFirstTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdPhoneType = "CELLPH";
            }

            if (secondTag == "HOMEEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "HOMEEML";
            }
            else if (secondTag == "COMMEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "COMMEML";
            }
            else if (secondTag == "CELLPH")
            {
                accountEnquiryInfo.phoneEmailIdPhone = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdPhoneType = "CELLPH";
            }

            if (thirdTag == "HOMEEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "HOMEEML";
            }
            else if (thirdTag == "COMMEML")
            {
                accountEnquiryInfo.phoneEmailIdEmail = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdEmailType = "COMMEML";
            }
            else if (thirdTag == "CELLPH")
            {
                accountEnquiryInfo.phoneEmailIdPhone = Util.GetSecondTagValue(detail, "PhoneEmailId");
                accountEnquiryInfo.phoneEmailIdPhoneType = "CELLPH";
            }

            //if (thirdTag == "COMMEML")
            //{
            //    accountEnquiryInfo.phoneEmailIdEmail = Util.GetThirdTagValue(detail, "PhoneEmailId");
            //    accountEnquiryInfo.phoneEmailIdEmailType = "COMMEML";
            //}
            return accountEnquiryInfo;
        }

        private string FormAccountCifEnquiryRequestPayload(string accountNumber)
        {
            var reqTranId = Util.TimeStampCode();
            var payload = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:soap=""http://soap.request.manager.redbox.stanbic.com/"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <soap:request>
                                     <reqTranId>{reqTranId}</reqTranId>
                                     <channel>INTERNET_BANKING</channel>
                                     <type>CIF_ENQUIRY</type>
                                     <submissionTime>{DateTime.Now.ToString("o")}</submissionTime>
                                     <body><![CDATA[<otherRequestDetails>
                                     <cifId></cifId>
                                     <cifType></cifType>
                                    <accountNumber>{accountNumber}</accountNumber>
                                    <moduleTranReferenceId>{reqTranId}</moduleTranReferenceId>
                                  </otherRequestDetails>]]></body>
                                  </soap:request>
                               </soapenv:Body>
                            </soapenv:Envelope>";
            return payload;
        }
    }
}