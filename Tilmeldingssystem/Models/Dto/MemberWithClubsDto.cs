namespace Tilmeldingssystem.Models.Dto
{
    public class MemberWithClubsDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public List<string> ClubNames { get; set; } = new List<string>();
    }
}
