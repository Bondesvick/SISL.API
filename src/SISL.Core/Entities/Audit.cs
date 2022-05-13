using System;

namespace SISL.Core.Entities
{
    public class Audit : BaseEntity
    {
        //public long Id { get; set; }
        public string ActionType { get; set; }

        public string Description { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}