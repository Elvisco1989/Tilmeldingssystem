namespace Tilmeldingssystem.TicketSystem
{
    public class TicketResponseDto
    {
        public int Id { get; set; }

        public string TicketNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Status { get; set; } // fx "åben", "lukket", "under behandling"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? ClosedAt { get; set; }
    }
}
