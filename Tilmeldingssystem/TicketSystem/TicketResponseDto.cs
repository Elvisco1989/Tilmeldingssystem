namespace Tilmeldingssystem.TicketSystem
{
    /// <summary>
    /// Data Transfer Object representing the details of a ticket response.
    /// </summary>
    public class TicketResponseDto
    {
        /// <summary>
        /// Unique identifier of the ticket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Formatted ticket number, e.g. "TICKET-0001".
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// Name of the person who created the ticket.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email address of the ticket creator.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Subject of the ticket.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Detailed message of the ticket.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Current status of the ticket, e.g. "åben", "lukket", "under behandling".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Timestamp when the ticket was created, defaults to UTC now.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Timestamp when the ticket was last updated, if any.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Timestamp when the ticket was closed, if applicable.
        /// </summary>
        public DateTime? ClosedAt { get; set; }

        /// <summary>
        /// Optional path to an attachment related to the ticket.
        /// </summary>
        public string? AttachmentPath { get; set; }
    }
}
