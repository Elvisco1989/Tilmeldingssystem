using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    public interface IMemberService
    {
        Task<string> RegisterMemberToClubAsync(MemberClubRegistrationDto dto);
    }
}