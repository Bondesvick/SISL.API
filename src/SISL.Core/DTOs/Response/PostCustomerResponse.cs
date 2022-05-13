using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SISL.Core.DTOs.Response
{
    public class PostCustomerResponse
    {
        [JsonProperty("DataTable")]
        public object DataTable { get; set; }

        [JsonProperty("StatusID")]
        public long StatusId { get; set; }

        [JsonProperty("StatusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty("OutValue")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string OutValue { get; set; }
    }
}