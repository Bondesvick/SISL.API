using System;

namespace SISL.Core.DTOs.Response
{
    public class SislHistoryDto
    {
        public int Id { get; set; }

        //public CustomerAccount CustomerAccount { get; set; }
        public int CustomerAccountId { get; set; }

        public string RequestId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public SislStatusDto SislStatus { get; set; }
    }
}