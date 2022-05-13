using System;
using System.Collections.Generic;

#nullable disable

namespace SISL.Infrastructure.Models
{
    public partial class Profile
    {
        public decimal Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Othernames { get; set; }
    }
}
