using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SISL.Core.DTOs.Response;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class SmileHelper : ISmileHelper
    {
        private readonly ILogger<SmileHelper> _logger;

        public SmileHelper(ILogger<SmileHelper> logger)
        {
            _logger = logger;
        }

        public async Task<(string, HttpStatusCode)> MakeRequestAndGetResponseGeneral(string datastring, string URL, string Method, bool hasHeader,
string Authorization, string ModuleId, string ContentType, string soapAction, string logPath)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream dataStream = null;
            string serverResponse = string.Empty;
            bool logger = false;
            try
            {
                _logger.LogInformation("Request payload -> " + datastring);

                request = (HttpWebRequest)WebRequest.Create(URL);
                request.ContentType = ContentType;// "application/json";
                request.Method = Method;
                if (!String.IsNullOrEmpty(soapAction)) { request.Headers.Add("SOAPAction", soapAction); }
                if (!String.IsNullOrEmpty(Authorization)) request.Headers.Add("Authorization", Authorization);
                if (!String.IsNullOrEmpty(ModuleId)) request.Headers.Add("MODULE_ID", ModuleId);
                if (URL.Contains("https://"))
                {
                    //supress unsigned certificate
                    // ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(IgnoreCertificateErrorHandler);
                }

                if (Method == "GET")
                {
                    using (response = (HttpWebResponse)await request.GetResponseAsync())
                    {
                        using (dataStream = response.GetResponseStream())
                        {
                            using (StreamReader streamReader = new StreamReader(dataStream))
                            {
                                //string responseString = streamReader.ReadToEnd();
                                string responseString = await streamReader.ReadToEndAsync();

                                _logger.LogInformation("Response payload -> " + responseString);

                                serverResponse = responseString;

                                if (response.StatusCode == HttpStatusCode.OK)
                                    return (serverResponse, HttpStatusCode.OK);

                                return (serverResponse, response.StatusCode);
                                //serverResponse = useRegExReplace ? Regex.Replace(responseString, @"^.+?\(|\)$", "") : responseString;
                            }
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    _logger.LogInformation($"Making a post request. Data -> " + datastring);
                    writer.WriteLine(datastring);
                    writer.Close();

                    // Send the data to the webserver
                    using (response = (HttpWebResponse)await request.GetResponseAsync())
                    {
                        using (dataStream = response.GetResponseStream())
                        {
                            using (StreamReader streamReader = new StreamReader(dataStream))
                            {
                                //string responseString = streamReader.ReadToEnd();
                                string responseString = await streamReader.ReadToEndAsync();
                                serverResponse = responseString;

                                _logger.LogInformation("Response payload -> " + responseString);

                                if (response.StatusCode == HttpStatusCode.OK)
                                    return (serverResponse, HttpStatusCode.OK);

                                _logger.LogInformation(serverResponse + " " + response.StatusCode);
                                _logger.LogInformation($"An error occurred while posting to {URL}", $"URL: {URL}");
                                return (serverResponse, response.StatusCode);
                                //logger = Logger.LogData("RESPONSE: " + responseString, logPath);
                                //serverResponse = useRegExReplace ? Regex.Replace(responseString, @"^.+?\(|\)$", "") : responseString;
                            }
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                HttpWebResponse webResp = (HttpWebResponse)webEx.Response;

                if (webResp != null)
                {
                    var encoding = Encoding.ASCII;
                    using (var reader = new System.IO.StreamReader(webResp.GetResponseStream(), encoding))
                    {
                        var astr = reader.ReadToEnd();
                        var responseText = webResp.StatusCode + " at Requery: " + astr;

                        _logger.LogError(webEx, responseText);
                        _logger.LogInformation("responseText");

                        var responseClass = JsonConvert.DeserializeObject<SmileError>(astr);
                        var message = responseClass.technicalInformations.FirstOrDefault()?.message;

                        _logger.LogInformation(message);

                        return (message, HttpStatusCode.BadRequest);

                        //throw;
                        //Logger.LogData("EXCEPTION: " + webEx.ToString() + "\n:Web Response:" + webEx.Response + "\n:PARSED RESPONSE:" + responseText, logPath);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occurred while making an http request -> {e.Message}", e);

                throw;
                //
                //return (ex.Message, HttpStatusCode.BadRequest);
            }
            return (String.Empty, HttpStatusCode.BadRequest);
        }
    }
}