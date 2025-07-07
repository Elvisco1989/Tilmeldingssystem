using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    public interface IActivityService
    {
        Task<MemberActivityRegistrationResultDto?> RegisterMemberToActivityAsync(MemberActivityRegistrationDto dto);
    }
}