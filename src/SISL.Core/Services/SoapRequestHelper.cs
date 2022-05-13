﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SISL.Core.Commons;
using SISL.Core.DTOs.Request.Redox;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class SoapRequestHelper : ISoapRequestHelper
    {
        private readonly IAppLogger _logger;
        private readonly IAppSettings _configSettings;

        public SoapRequestHelper(IAppLogger logger, IAppSettings settings)
        {
            _logger = logger;
            _configSettings = settings;
        }

        public async Task<BaseRedboxResponse> SoapCall(string soapRequest, string soapAction, string url, string moduleId = "", string authId = "", string contentType = "text/xml")
        {
            moduleId = string.IsNullOrEmpty(moduleId) ? _configSettings.GetString("AppSettings:ModuleId") : moduleId;
            authId = string.IsNullOrEmpty(authId) ? _configSettings.GetString("AppSettings:AuthorizationId") : authId;
            var k = new BaseRedboxResponse("99", "Init");
            var reqId = $"{soapAction}_{Util.TimeStampCode()}";
            _logger.Info($"{soapAction} API REQ: {reqId}\nModuleId:{moduleId}|AuthId:{authId}\n{soapRequest}");
            try
            {
                var uri = new Uri(url);
                var baseurl = uri.Scheme + "://" + uri.Authority;
                var path = uri.PathAndQuery;

                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
                using HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback += ValidateServerCertificate;

                using var client = new HttpClient(clientHandler)
                {
                    BaseAddress = new Uri(baseurl)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                if (!String.IsNullOrEmpty(soapAction)) { client.DefaultRequestHeaders.Add("SOAPAction", soapAction); }
                if (!String.IsNullOrEmpty(moduleId)) { client.DefaultRequestHeaders.Add("module_id", $"{moduleId}"); }
                if (!String.IsNullOrEmpty(authId)) { client.DefaultRequestHeaders.Add("authorization", $"basic {authId}"); }
                HttpResponseMessage responseMessage = null;
                HttpContent contentPost = new StringContent(soapRequest, Encoding.UTF8, contentType);
                responseMessage = await client.PostAsync(url, contentPost);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resp = await responseMessage.Content.ReadAsStringAsync();
                    k = new BaseRedboxResponse("000", resp);
                }
                else
                {
                    var resp = await responseMessage.Content.ReadAsStringAsync();
                    k = new BaseRedboxResponse("9XX", resp);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex: ex);
                k = new BaseRedboxResponse("9XX", ex.Message);
            }

            var responseLogMsg = $"{soapAction} API RESP: {reqId} -> {JsonConvert.SerializeObject(k)}";

            var formatLogMsg = Regex.Escape(responseLogMsg);
            try
            {
                _logger.Info(formatLogMsg.Replace('"', '\"'));
            }
            catch (Exception ex)
            {
                _logger.Error("could not log API response message this time", null, ex);
                return k;
            }
            return k;
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return "0".Trim().Length < 5;
        }
    }
}