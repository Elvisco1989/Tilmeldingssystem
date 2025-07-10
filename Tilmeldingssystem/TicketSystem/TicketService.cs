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
            // Validate that the Member exists
            var member = _context.Members.Find(createTicketDto.MemberId);
            if (member == null)
            {
                throw new ArgumentException("Invalid MemberId. Ticket must be linked to an existing member.");
            }

            var ticket = new Ticket
            {
                TicketNumber = Guid.NewGuid().ToString(),
                Name = createTicketDto.Name,
                Email = createTicketDto.Email,
                Subject = createTicketDto.Subject,
                Message = createTicketDto.Message,
                Status = "åben",
                CreatedAt = DateTime.UtcNow,
                MemberId = createTicketDto.MemberId // 👈 Important for the FK
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
                CreatedAt = ticket.CreatedAt
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
                    Status = ticket.Status,
                    CreatedAt = ticket.CreatedAt
                })
                .ToList();
        }

    }
}
