using System.ComponentModel.DataAnnotations;

namespace SISL.Core.DTOs.Request
{
    public class AccountRequestParamsDto
    {
        [Required]
        public long Id { get; set; }
    }
}