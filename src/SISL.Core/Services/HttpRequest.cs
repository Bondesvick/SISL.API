using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SISL.Core.DTOs.Response.IdentityVerification;
using SISL.Core.Interfaces;

namespace SISL.Core.Services
{
    public class HttpRequest : IHttpRequest
    {
        private readonly ILogger<HttpRequest> _logger;

        public HttpRequest(ILogger<HttpRequest> logger)
        {
            _logger = logger;
        }

        public async Task<T> AsyncPost<T>(Dictionary<string, string> values, string url, string base64 = null, byte[] byteArray = null)
        {
            var content = new FormUrlEncodedContent(values);

            //HttpContent metaDataContent = new ByteArrayContent();

            MultipartFormDataContent multipartContent = new MultipartFormDataContent();

            ByteArrayContent byteContent;
            if (byteArray != null)
            {
                byteContent = new ByteArrayContent(byteArray);
                multipartContent.Add(byteContent);
            }

            StringContent stringContent;
            if (base64 != null)
            {
                stringContent = new StringContent(
                    base64,
                    System.Text.Encoding.UTF8);
                multipartContent.Add(stringContent);
            }

            using (var client = new HttpClient())
            {
                try
                {
                    //var file = File.OpenRead(Path.Combine(Config.ExampleFilesAbsolutePath, filename));

                    // Create json for body
                    //var content = new JObject(json);

                    client.BaseAddress = new Uri(url);

                    var requestUri = QueryHelpers.AddQueryString(url, values);
                    var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
                    //{
                    //    Content = fileContent
                    //};

                    if (byteArray != null)
                    {
                        var fileContent = new ByteArrayContent(byteArray);
                        request.Content = fileContent;
                    }

                    //request.Content = multipartContent;

                    //request.Content = new StringContent(
                    //    content.ToString(),
                    //    Encoding.UTF8,
                    //    "application/json"
                    //);

                    _logger.LogInformation("Posting customer account details", values);
                    var res = await client.SendAsync(request);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        string responseString = await res.Content.ReadAsStringAsync();
                        var responseClass = JsonConvert.DeserializeObject<T>(responseString);
                        return responseClass;
                    }

                    //var httpResponseMessage = await client.PostAsync(url, content);
                    //if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    //{
                    //    string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                    //    var responseClass = JsonConvert.DeserializeObject<T>(responseString);
                    //    return responseClass;
                    //}
                }
                catch (OperationCanceledException e)
                {
                    _logger.LogError($"Error occurred while posting Customer accounts -> {e.Message}", e);
                    throw;
                }
            }
            return default;
        }

        public async Task<T> GetWithQueryAsync<T>(Dictionary<string, string> values, string url)
        {
            var content = new FormUrlEncodedContent(values);

            using (var client = new HttpClient())
            {
                try
                {
                    // Create json for body
                    //var content = new JObject(json);

                    client.BaseAddress = new Uri(url);

                    var requestUri = QueryHelpers.AddQueryString(url, values);
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

                    //request.Content = new StringContent(
                    //    content.ToString(),
                    //    Encoding.UTF8,
                    //    "application/json"
                    //);

                    _logger.LogInformation("Posting customer account details", values);
                    var res = await client.SendAsync(request);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        string responseString = await res.Content.ReadAsStringAsync();
                        var responseClass = JsonConvert.DeserializeObject<T>(responseString);
                        return responseClass;
                    }

                    //var httpResponseMessage = await client.PostAsync(url, content);
                    //if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    //{
                    //    string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                    //    var responseClass = JsonConvert.DeserializeObject<T>(responseString);
                    //    return responseClass;
                    //}
                }
                catch (OperationCanceledException e)
                {
                    _logger.LogError($"Error occurred while posting Customer accounts -> {e.Message}", e);
                    throw;
                }
            }
            return default;
        }

        public async Task<T> AsyncGet<T>(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var httpResponseMessage = await client.GetAsync(url);

                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                    {
                        // Do something...

                        string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                        var responseClass = JsonConvert.DeserializeObject<T>(responseString);
                        return responseClass;
                    }
                }
                catch (OperationCanceledException e)
                {
                    _logger.LogError($"Error occurred while getting Customer accounts -> {e.Message}", e);

                    throw;
                }
            }

            return default;
        }
    }
}