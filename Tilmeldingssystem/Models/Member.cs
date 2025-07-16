using System.ComponentModel.DataAnnotations;
using Tilmeldingssystem.TicketSystem;

namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents a member with personal details and related entities.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Primary key for the Member.
        /// </summary>
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// Full name of the member.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email address of the member.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the member.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Date of birth of the member.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Navigation property for the member's club memberships.
        /// </summary>
        public ICollection<MemberClub> MemberClubs { get; set; } = new List<MemberClub>();

        /// <summary>
        /// Navigation property for the member's activity participations.
        /// </summary>
        public ICollection<MemberActivity> MemberActivities { get; set; } = new List<MemberActivity>();

        /// <summary>
        /// List of tickets created by the member.
        /// </summary>
        public List<Ticket> Tickets { get; set; } = new();
    }
}
