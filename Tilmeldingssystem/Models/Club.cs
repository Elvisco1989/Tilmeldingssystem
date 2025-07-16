using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents a club with its details and associated members.
    /// </summary>
    public class Club
    {
        /// <summary>
        /// Primary key for the Club.
        /// </summary>
        [Key]
        public int ClubId { get; set; }

        /// <summary>
        /// Name of the club.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location of the club.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Description of the club.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Navigation property for members associated with the club.
        /// </summary>
        public List<MemberClub> MemberClubs { get; set; } = new List<MemberClub>();
    }
}
