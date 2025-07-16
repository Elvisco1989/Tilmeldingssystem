namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents the many-to-many relationship between a Member and a Club.
    /// </summary>
    public class MemberClub
    {
        /// <summary>
        /// Foreign key for Member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Navigation property to the Member.
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Foreign key for Club.
        /// </summary>
        public int ClubId { get; set; }

        /// <summary>
        /// Navigation property to the Club.
        /// </summary>
        public Club Club { get; set; }
    }
}
