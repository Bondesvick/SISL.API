using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.DTOs.Response.IdentityVerification;
using SISL.Core.Exceptions;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class IdValidationService : IIdValidationService
    {
        //private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private readonly ILogger<IdValidationService> _logger;
        private readonly ISmileHelper _smileHelper;

        public IdValidationService(IConfiguration configuration, ILogger<IdValidationService> logger, ISmileHelper smileHelper)
        {
            //_httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _smileHelper = smileHelper;
        }

        public async Task<(VerifyIdResponseDto, string)> Validate(ValidationModel identityRequestBody)
        {
            try
            {
                //identityRequestBody.Dob = DateTime.ParseExact(identityRequestBody.Dob, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToShortDateString();
                var moduleId = _configuration["AppSettings:BVNModuleId"];
                var channel = _configuration["AppSettings:IdChannel"];

                var idType = identityRequestBody.Type == "NIMC" ? "NIN_SLIP" :
                    identityRequestBody.Type == "Voter's card" ? "VOTER_ID" :
                    identityRequestBody.Type == "Driver's liscense" ? "DRIVERS_LICENSE" : "BVN";

                if (idType == "BVN")
                {
                    // do BVN validation
                    var bvnDetails = new
                    {
                        requestId = "12345",
                        bvnRequest = new
                        {
                            bvns = new[] { identityRequestBody.IdNumber }
                        }
                    };

                    var bvnJsonRequestString = JsonConvert.SerializeObject(bvnDetails);

                    var bvnUrl = _configuration["AppSettings:BVNBaseEndPoint"];

                    var (idRespone, bvnCode) = await _smileHelper.MakeRequestAndGetResponseGeneral(bvnJsonRequestString, bvnUrl, "POST", false, "", moduleId, "application/json", "", "");

                    if (bvnCode == HttpStatusCode.OK)
                    {
                        var responseClass = JsonConvert.DeserializeObject<BvnValidationResponse>(idRespone);

                        var data = new VerifyIdResponseDto
                        {
                            ResultText = responseClass.ResponseMessage,
                            Address = "",
                            DateOfBirth = responseClass.DateOfBirth,
                            FirstName = responseClass.FirstName,
                            FullName = "No Data",
                            Gender = "No Data",
                            LastName = responseClass.LastName,
                            OtherName = responseClass.MiddleName,
                            PhoneNumber = "No Data",
                            ReturnPersonalInfo = responseClass.ResponseCode,
                            VerifyIdNumber = ""
                        };

                        return (data, "");
                    }

                    return (null, idRespone);
                }

                var details = new
                {
                    country = "NG",
                    idType,
                    idNumber = identityRequestBody.IdNumber,
                    firstName = identityRequestBody.FirstName,
                    middleName = identityRequestBody.MiddleName,
                    lastName = identityRequestBody.LastName,
                    phoneNumber = identityRequestBody.PhoneNumber,
                    dob = identityRequestBody.DateOfBirth.ToString("yyyy-MM-dd"),
                    channel,
                    moduleId
                };

                var jsonRequestString = JsonConvert.SerializeObject(details);

                _logger.LogInformation("Validating Customer details:, Payload -> " + jsonRequestString);

                string url = _configuration["AppSettings:IdBaseEndPoint"];

                var (respone, code) = await _smileHelper.MakeRequestAndGetResponseGeneral(jsonRequestString, url, "POST", false, "", "", "application/json", "", "");

                if (code == HttpStatusCode.OK)
                {
                    var responseClass = JsonConvert.DeserializeObject<IdVerificationResponse>(respone);

                    var data = new VerifyIdResponseDto
                    {
                        ResultText = responseClass?.ResultText,
                        Address = responseClass?.Address,
                        DateOfBirth = responseClass?.FullData?.birthdate ?? responseClass?.FullData?.DOB_Y ?? responseClass?.DOB,
                        FirstName = responseClass?.FullData?.firstname,
                        FullName = responseClass?.FullName ?? responseClass?.FullData?.name,
                        Gender = responseClass?.FullData?.gender ?? responseClass?.Gender,
                        LastName = responseClass?.FullData?.surname ?? responseClass?.FullData?.LastName,
                        OtherName = responseClass?.FullData?.middlename ?? responseClass?.FullData?.otherName,
                        PhoneNumber = responseClass?.PhoneNumber,
                        ReturnPersonalInfo = responseClass?.Actions?.Return_Personal_Info,
                        VerifyIdNumber = responseClass?.Actions?.Verify_ID_Number
                    };

                    return (data, "");
                }

                return (null, respone);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while validating Customer accounts -> {e.Message}", e);

                throw;
            }
        }

        //public async Task<ValidateIdentityResponseDTO> ValidateIdentity(ValidateIdentityRequestDto identityRequestBody)
        //{
        //    try
        //    {
        //        if (_configuration["AppSettings:UseSmileIdentity"] != "1")
        //        {
        //            return new ValidateIdentityResponseDTO();
        //        }

        //        identityRequestBody.ModuleId = _configuration["AppSettings:RedboxModuleId"];

        //        var jsonRequestString = JsonConvert.SerializeObject(identityRequestBody);

        //        _logger.LogInformation(jsonRequestString);

        //        var request = new StringContent(jsonRequestString, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PostAsync(string.Empty, request);

        //        var responseString = await response.Content.ReadAsStringAsync();

        //        _logger.LogInformation(responseString);

        //        var responseClass = JsonConvert.DeserializeObject<JObject>(responseString);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError("Received invalid HTTP response status " + (int)response.StatusCode + " " + responseString);

        //            var message = responseClass.SelectToken("technicalInformations").FirstOrDefault().SelectToken("message").ToString();

        //            throw new BadRequestException(message);
        //        }

        //        if (responseClass.SelectToken("ResultCode").ToString() == "1012")
        //        {
        //            return new ValidateIdentityResponseDTO
        //            {
        //                FullName = responseClass.SelectToken("FullName").ToString()
        //            };
        //        }

        //        throw new BadRequestException(responseClass.SelectToken("ResultText").ToString());
        //    }
        //    catch (WebException webEx)
        //    {
        //        var responseText = webEx.Message;

        //        var webResp = (HttpWebResponse)webEx.Response;

        //        if (webResp == null) throw new Exception(responseText);

        //        await using var dataStream = webResp.GetResponseStream();

        //        if (dataStream == null) throw new Exception(responseText);

        //        using var reader = new StreamReader(dataStream, Encoding.ASCII);

        //        responseText = webResp.StatusCode + " at ReQuery: " + await reader.ReadToEndAsync();

        //        throw new Exception(responseText);
        //    }
        //}
    }
}