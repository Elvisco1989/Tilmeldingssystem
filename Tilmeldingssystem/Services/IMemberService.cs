using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    /// <summary>
    /// Service interface for member-related operations.
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// Registers a member to a club asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing member and club IDs for registration.</param>
        /// <returns>A string message indicating success or failure.</returns>
        Task<string> RegisterMemberToClubAsync(MemberClubRegistrationDto dto);
    }
}
