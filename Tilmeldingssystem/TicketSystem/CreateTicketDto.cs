namespace Tilmeldingssystem.TicketSystem
{
    public class CreateTicketDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; } 

        public string Message { get; set; }

        public int MemberId { get; set; } // 👈 Required now
    }
}
