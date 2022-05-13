namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FetchSessionId
    {
        [JsonProperty("DataTable")]
        public SessionData DataTable { get; set; }

        [JsonProperty("StatusID")]
        public long StatusId { get; set; }

        [JsonProperty("StatusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty("OutValue")]
        public Guid OutValue { get; set; }
    }

    public partial class SessionData
    {
        [JsonProperty("ColumnDef")]
        public Dictionary<string, string> ColumnDef { get; set; }

        [JsonProperty("Rows")]
        public Dictionary<string, string>[] Rows { get; set; }
    }
}