namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Data transfer object for registering a member to a club.
    /// </summary>
    public class MemberClubRegistrationDto
    {
        /// <summary>
        /// Gets or sets the ID of the member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the club.
        /// </summary>
        public int ClubId { get; set; }
    }
}
