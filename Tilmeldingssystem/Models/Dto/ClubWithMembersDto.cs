namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Data Transfer Object representing a club along with its member names.
    /// </summary>
    public class ClubWithMembersDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the club.
        /// </summary>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets the club's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the club.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description of the club.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of member names associated with the club.
        /// </summary>
        public List<string> MemberNames { get; set; } = new List<string>();
    }
}
