using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<MemberClub> MemberClubs { get; set; } = new List<MemberClub>();

        public ICollection<MemberActivity> MemberActivities { get; set; } = new List<MemberActivity>();

    }
}
