
namespace Tilmeldingssystem.TicketSystem
{
    public interface ITicketService
    {
        TicketResponseDto CreateTicket(CreateTicketDto createTicketDto);
        List<TicketResponseDto> GetAllTickets();
    }
}