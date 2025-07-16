using Tilmeldingssystem.Models;
using System;

namespace Tilmeldingssystem.TicketSystem
{
    /// <summary>
    /// Represents a support or inquiry ticket submitted by a member or user.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Primary key identifier for the ticket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique formatted ticket number (e.g., "TICKET-0001").
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
        /// Subject or title of the ticket.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Detailed message describing the issue or inquiry.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Current status of the ticket (e.g., "åben", "lukket", "under behandling").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// UTC date and time when the ticket was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional foreign key linking to the member who created the ticket.
        /// </summary>
        public int? MemberId { get; set; }

        /// <summary>
        /// Navigation property to the member entity.
        /// </summary>
        public Member? Member { get; set; }

        /// <summary>
        /// Optional path to an attached file for this ticket.
        /// </summary>
        public string? AttachmentPath { get; set; }
    }
}
