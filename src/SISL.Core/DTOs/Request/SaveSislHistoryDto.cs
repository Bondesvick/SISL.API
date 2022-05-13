using System;

namespace SISL.Core.DTOs.Request
{
    public class SaveSislHistoryDto
    {
        public int CustomerAccountId { get; set; }
        public string RequestId { get; set; }
        public string Comment { get; set; }
        public string Risk { get; set; }
        public string CommentDate { get; set; }
        public string CommentBy { get; set; }
        public string Status { get; set; }
        public string AccountStatus { get; set; }
        public string ApprovedBy { get; set; }
        public string ApproverIp { get; set; }
        public string Email { get; set; }
        public string LastUpdatedBy { get; set; }
        public string ReasonForRework { get; set; }
    }
}