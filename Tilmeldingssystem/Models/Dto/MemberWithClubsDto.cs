namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Data transfer object representing a member along with the names of the clubs they belong to.
    /// </summary>
    public class MemberWithClubsDto
    {
        /// <summary>
        /// Gets or sets the full name of the member.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the member.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the list of club names the member is associated with.
        /// </summary>
        public List<string> ClubNames { get; set; } = new List<string>();
    }
}
