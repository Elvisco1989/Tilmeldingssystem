namespace Tilmeldingssystem.Models.Dto
{
    public class MemberActivityRegistrationResultDto
    {
        public string ActivityName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string MemberName { get; set; } = string.Empty;
    }
}
