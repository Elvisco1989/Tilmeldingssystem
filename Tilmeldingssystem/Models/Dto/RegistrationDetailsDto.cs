namespace Tilmeldingssystem.Models.Dto
{
    public class RegistrationDetailsDto
    {
        public string MemberName { get; set; }

        public string ActivityName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
