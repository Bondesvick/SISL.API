using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.Entities
{
    public class SislDocument : BaseEntity
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string ContentOrPath { get; set; }
        public string ContentType { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
        public long CustomerAccountId { get; set; }
    }
}