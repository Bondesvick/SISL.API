using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.DTOs.Response
{
    public class SmileError
    {
        public string timestamp { get; set; }
        public List<TechnicalInformation> technicalInformations { get; set; }
    }

    public class TechnicalInformation
    {
        public string code { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string userFriendlyMessage { get; set; }
    }
}