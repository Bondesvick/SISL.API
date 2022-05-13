using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.DTOs.Response
{
    public class SislStatusDto
    {
        public int Id { get; set; }
        public string status { get; set; }

        public long SislHistoryId { get; set; }
    }
}