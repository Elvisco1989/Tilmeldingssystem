using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<MemberClub> MemberClubs { get; set; } = new List<MemberClub>();
    }
}
