namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Represents a request to register a member for a specific activity.
    /// Contains the member's ID and the activity's ID.
    /// </summary>
    public class MemberActivityRegistrationDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the activity.
        /// </summary>
        public int ActivityId { get; set; }
    }
}
