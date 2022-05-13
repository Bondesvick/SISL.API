namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FetchCustomer
    {
        [JsonProperty("DataTable")]
        public CustomerData DataTable { get; set; }

        [JsonProperty("StatusID")]
        public long StatusId { get; set; }

        [JsonProperty("StatusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty("OutValue")]
        public string OutValue { get; set; }
    }

    public partial class CustomerData
    {
        [JsonProperty("ColumnDef")]
        public Dictionary<string, string> ColumnDef { get; set; }

        [JsonProperty("Rows")]
        public Dictionary<string, string>[] Rows { get; set; }
    }
}