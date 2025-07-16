using Tilmeldingssystem.AppDbcontext;

namespace Tilmeldingssystem.TicketSystem
{
    /// <summary>
    /// Service responsible for managing ticket operations such as creating tickets
    /// and retrieving tickets from the database.
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public TicketService(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new ticket, handles optional file attachment saving, generates
        /// a unique ticket number, and saves the ticket to the database.
        /// </summary>
        /// <param name="createTicketDto">Data transfer object containing ticket creation details</param>
        /// <returns>Response DTO with ticket information</returns>
        public TicketResponseDto CreateTicket(CreateTicketDto createTicketDto)
        {
            string? savedFilePath = null;

            // Handle file attachment if present
            if (createTicketDto.Attachment != null)
            {
                var uploadsFolder = Path.Combine("wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid() + Path.GetExtension(createTicketDto.Attachment.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    createTicketDto.Attachment.CopyTo(stream);
                }

                savedFilePath = $"/uploads/{uniqueFileName}";
            }

            // Generate next sequential ticket number (e.g., TICKET-0001)
            var lastTicket = _context.Tickets
                .OrderByDescending(t => t.Id) // Could use CreatedAt if preferred
                .FirstOrDefault();

            int nextTicketNumber = 1;
            if (lastTicket != null && int.TryParse(lastTicket.TicketNumber?.Replace("TICKET-", ""), out int lastNumber))
            {
                nextTicketNumber = lastNumber + 1;
            }

            var formattedTicketNumber = $"TICKET-{nextTicketNumber:D4}";

            var ticket = new Ticket
            {
                TicketNumber = formattedTicketNumber,
                Name = createTicketDto.Name,
                Email = createTicketDto.Email,
                Subject = createTicketDto.Subject,
                Message = createTicketDto.Message,
                Status = "åben",
                CreatedAt = DateTime.UtcNow,
                MemberId = createTicketDto.MemberId,
                AttachmentPath = savedFilePath
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return new TicketResponseDto
            {
                Id = ticket.Id,
                TicketNumber = ticket.TicketNumber,
                Name = ticket.Name,
                Email = ticket.Email,
                Subject = ticket.Subject,
                Message = ticket.Message,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt,
                AttachmentPath = ticket.AttachmentPath
            };
        }

        /// <summary>
        /// Retrieves all tickets from the database as a list of response DTOs.
        /// </summary>
        /// <returns>List of all ticket response DTOs</returns>
        public List<TicketResponseDto> GetAllTickets()
        {
            return _context.Tickets.Select(ticket => new TicketResponseDto
            {
                Id = ticket.Id,
                TicketNumber = ticket.TicketNumber,
                Name = ticket.Name,
                Email = ticket.Email,
                Subject = ticket.Subject,
                Message = ticket.Message,
                AttachmentPath = ticket.AttachmentPath,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt,
            }).ToList();
        }

        /// <summary>
        /// Retrieves all tickets for a specific member by member ID.
        /// Throws ArgumentException if the member does not exist.
        /// </summary>
        /// <param name="memberId">ID of the member</param>
        /// <returns>List of ticket response DTOs for the member</returns>
        /// <exception cref="ArgumentException">Thrown when member does not exist</exception>
        public List<TicketResponseDto> GetTicketsByMemberId(int memberId)
        {
            // Validate member existence
            var memberExists = _context.Members.Any(m => m.MemberId == memberId);
            if (!memberExists)
            {
                throw new ArgumentException("Member with the specified ID does not exist.");
            }

            return _context.Tickets
                .Where(ticket => ticket.MemberId == memberId)
                .Select(ticket => new TicketResponseDto
                {
                    Id = ticket.Id,
                    TicketNumber = ticket.TicketNumber,
                    Name = ticket.Name,
                    Email = ticket.Email,
                    Subject = ticket.Subject,
                    Message = ticket.Message,
                    AttachmentPath = ticket.AttachmentPath,
                    Status = ticket.Status,
                    CreatedAt = ticket.CreatedAt
                })
                .ToList();
        }
    }
}
