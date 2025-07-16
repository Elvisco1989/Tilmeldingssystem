namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Data Transfer Object representing basic information about a club.
    /// </summary>
    public class ClubDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the club.
        /// </summary>
        public int ClubId { get; set; }

        /// <summary>
        /// Gets or sets the name of the club.
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
    }
}
