using Microsoft.AspNetCore.Http;

namespace Tilmeldingssystem.TicketSystem
{
    /// <summary>
    /// Data Transfer Object for creating a new support ticket.
    /// </summary>
    public class CreateTicketDto
    {
        /// <summary>
        /// Name of the person creating the ticket.
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
        /// Detailed message describing the issue or request.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Optional member ID associated with the ticket.
        /// </summary>
        public int? MemberId { get; set; }

        /// <summary>
        /// Optional file attachment uploaded with the ticket.
        /// </summary>
        public IFormFile? Attachment { get; set; }
    }
}
