using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SISL.Core.DTOs.Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ValidateIdentityRequestDto
    {
        [JsonProperty("country")] public string Country { get; set; } = "NG";

        [Required]
        [JsonProperty("idType")]
        public string IdType { get; set; }

        [Required]
        [JsonProperty("idNumber")]
        public string IdNumber { get; set; }

        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; } = "MOBILE_APP";

        [JsonProperty("moduleId")]
        public string ModuleId { get; set; }
    }
}