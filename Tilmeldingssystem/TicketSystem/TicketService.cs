using Tilmeldingssystem.AppDbcontext;

namespace Tilmeldingssystem.TicketSystem
{
    public class TicketService : ITicketService
    {
        private readonly TilmeldingsDbContext _context;

        public TicketService(TilmeldingsDbContext context)
        {
            _context = context;
        }

        
        public TicketResponseDto CreateTicket(CreateTicketDto createTicketDto)
        {
            string? savedFilePath = null;

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

            // 🧮 Generate next ticket number
            var lastTicket = _context.Tickets
                .OrderByDescending(t => t.Id) // or CreatedAt
                .FirstOrDefault();

            int nextTicketNumber = 1;
            if (lastTicket != null && int.TryParse(lastTicket.TicketNumber?.Replace("TICKET-", ""), out int lastNumber))
            {
                nextTicketNumber = lastNumber + 1;
            }

            var formattedTicketNumber = $"TICKET-{nextTicketNumber:D4}"; // e.g., TICKET-0001

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
                AttachmentPath = ticket.AttachmentPath, // optional
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt,

            }).ToList();
        }

        public List<TicketResponseDto> GetTicketsByMemberId(int memberId)
        {
            // Optionally: check if the member exists
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
                    AttachmentPath = ticket.AttachmentPath, // optional
                    Status = ticket.Status,
                    CreatedAt = ticket.CreatedAt
                })
                .ToList();
        }

    }
}
