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
            var ticket = new Ticket
            {
                TicketNumber = Guid.NewGuid().ToString(),
                Name = createTicketDto.Name,
                Email = createTicketDto.Email,
                Subject = createTicketDto.Subject,

                Message = createTicketDto.Message,
                Status = "åben",
                CreatedAt = DateTime.UtcNow
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
    }
}
