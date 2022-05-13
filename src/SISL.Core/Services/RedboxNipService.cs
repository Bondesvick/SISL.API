using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SISL.Core.Commons;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Request.Redox;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class RedboxNipService : IRedboxNipService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RedboxNipService> _logger;
        private readonly IAppSettings _configSettings;
        private readonly ISoapRequestHelper _soapRequestHelper;

        public RedboxNipService(
            IConfiguration configuration, ILogger<RedboxNipService> logger,
            IAppSettings settings, ISoapRequestHelper soapRequestHelper)
        {
            _configuration = configuration;
            _logger = logger;
            _configSettings = settings;
            _soapRequestHelper = soapRequestHelper;
        }

        public async Task<(bool scuccess, string value, string description)> ValidateAccount(AccountDetailsRequest request)
        {
            var resp = new BaseRequestManagerResponse<string>();
            try
            {
                var payload = GetRequestPayload(request);
                var requestResponse = await _soapRequestHelper.SoapCall(payload, "NIPOperation", _configSettings.GetString("AppSettings:NipUrl"));

                if (requestResponse.ResponseCode != "000")
                {
                    resp.ResponseCode = requestResponse.ResponseCode;
                    resp.ResponseDescription = requestResponse.ResponseDescription.Contains("faultstring") ? Util.GetXmlTagValue(requestResponse.ResponseDescription, "faultstring") : requestResponse.ResponseDescription;

                    return (false, "", resp.ResponseDescription);
                }

                resp.ResponseCode = Util.GetXmlTagValue(requestResponse.ResponseDescription, "ResponseCode",
                    ignoreCase: false);
                resp.ResponseDescription = Util.GetXmlTagValue(requestResponse.ResponseDescription,
                    "ResponseDescription", ignoreCase: false);

                if (resp.ResponseCode == "000" || resp.ResponseCode == "00" || resp.ResponseCode == "202")
                {
                    var fullName = Util.GetXmlTagValue(requestResponse.ResponseDescription,
                        "DestinationAccountName", ignoreCase: false);

                    return (true, fullName, resp.ResponseDescription);
                }

                return (false, "", resp.ResponseDescription);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while validating account -> {e.Message}", e);

                throw;
            }
        }

        private string GetRequestPayload(AccountDetailsRequest request)
        {
            var payload =
                $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:soap=""http://soap.nip.outbound.redbox.stanbic.com/"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <soap:NIPOperation>
                            <TransactionReference>1026286021</TransactionReference>
                            <OperationType>1</OperationType>
                            <DestinationAccountNumber>{request.AccountNumber}</DestinationAccountNumber>
                            <DestinationBankCode>{request.DestinationBankCode}</DestinationBankCode>
                            <ChannelCode>2</ChannelCode>
                        </soap:NIPOperation>
                    </soapenv:Body>
                    </soapenv:Envelope>";

            return payload;
        }
    }
}