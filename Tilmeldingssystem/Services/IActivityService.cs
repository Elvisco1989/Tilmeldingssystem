using Tilmeldingssystem.Models.Dto;

namespace Tilmeldingssystem.Services
{
    /// <summary>
    /// Service interface for activity-related operations.
    /// </summary>
    public interface IActivityService
    {
        /// <summary>
        /// Registers a member to an activity asynchronously.
        /// </summary>
        /// <param name="dto">The DTO containing member and activity registration details.</param>
        /// <returns>
        /// A <see cref="MemberActivityRegistrationResultDto"/> indicating the result of the registration,
        /// or null if the registration failed.
        /// </returns>
        Task<MemberActivityRegistrationResultDto?> RegisterMemberToActivityAsync(MemberActivityRegistrationDto dto);
    }
}
