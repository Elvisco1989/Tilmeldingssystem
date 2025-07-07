namespace Tilmeldingssystem.Models.Dto
{
    public class ClubWithMembersDto
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> MemberNames { get; set; } = new List<string>();
    }
}
