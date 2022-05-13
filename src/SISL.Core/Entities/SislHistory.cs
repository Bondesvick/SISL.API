using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.Entities
{
    public class SislHistory : BaseEntity
    {
        //public int Id { get; set; }
        public CustomerAccount CustomerAccount { get; set; }

        public long CustomerAccountId { get; set; }
        public string RequestId { get; set; }
        public string Comment { get; set; }
        public string LastUpdatedBy { get; set; }

        //public string Risk { get; set; }
        public DateTime CommentDate { get; set; }

        public string CommentBy { get; set; }

        public SislStatus SislStatus { get; set; }
    }
}