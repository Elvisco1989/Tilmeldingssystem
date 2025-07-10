
namespace Tilmeldingssystem.TicketSystem
{
    public interface ITicketService
    {
        TicketResponseDto CreateTicket(CreateTicketDto createTicketDto);
        List<TicketResponseDto> GetAllTickets();
        List<TicketResponseDto> GetTicketsByMemberId(int memberId);
    }
}