using System;
using System.ComponentModel.DataAnnotations;

namespace SISL.Core.DTOs.Request
{
    public class SpoolDto
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; }

        public int? Count { get; set; }
        //public string Criteria { get; set; }
    }
}