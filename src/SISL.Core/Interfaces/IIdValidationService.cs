using System.Threading.Tasks;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;

namespace SISL.Core.Interfaces
{
    public interface IIdValidationService
    {
        Task<(VerifyIdResponseDto, string)> Validate(ValidationModel identityRequestBody);

        //Task<ValidateIdentityResponseDTO> ValidateIdentity(ValidateIdentityRequestDto identityRequestBody);
    }
}