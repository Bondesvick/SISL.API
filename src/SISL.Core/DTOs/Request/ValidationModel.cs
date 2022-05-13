using System;
using System.Collections.Generic;
using System.Text;

namespace SISL.Core.DTOs.Request
{
    public class ValidationModel
    {
        public string Type { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}