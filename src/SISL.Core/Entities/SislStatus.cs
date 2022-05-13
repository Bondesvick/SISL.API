using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.Entities
{
    public class SislStatus : BaseEntity
    {
        public string status { get; set; }
        public SislHistory SislHistory { get; set; }
        public long SislHistoryId { get; set; }
    }
}