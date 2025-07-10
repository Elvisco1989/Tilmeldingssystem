using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.TicketSystem
{
    public class Ticket
    {
        public int Id { get; set; }

        public string TicketNumber { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string Status { get; set; } // fx "åben", "lukket", "under behandling"


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public int MemberId { get; set; }

        // Navigation property
        public Member Member { get; set; }
    }
}
