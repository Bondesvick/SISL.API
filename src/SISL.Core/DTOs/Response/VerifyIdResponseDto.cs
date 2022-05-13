using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SISL.Core.DTOs.Response
{
    public class VerifyIdResponseDto
    {
        [JsonProperty("ResultText")]
        public string ResultText { get; set; }
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("OtherName")]
        public string OtherName { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("VerifyIdNumber")]
        public string VerifyIdNumber { get; set; }

        [JsonProperty("ReturnPersonalInfo")]
        public string ReturnPersonalInfo { get; set; }
    }
}