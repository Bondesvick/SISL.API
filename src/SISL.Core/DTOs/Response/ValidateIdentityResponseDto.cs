using Newtonsoft.Json;

namespace SISL.Core.DTOs.Response
{
    public class ValidateIdentityResponseDto
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }
    }
}