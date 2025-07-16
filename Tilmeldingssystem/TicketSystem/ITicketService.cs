namespace Tilmeldingssystem.TicketSystem
{
    /// <summary>
    /// Service interface for managing support tickets.
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// Creates a new ticket based on the provided data transfer object.
        /// </summary>
        /// <param name="createTicketDto">The data transfer object containing ticket details.</param>
        /// <returns>A DTO representing the created ticket.</returns>
        TicketResponseDto CreateTicket(CreateTicketDto createTicketDto);

        /// <summary>
        /// Retrieves all tickets in the system.
        /// </summary>
        /// <returns>A list of DTOs representing all tickets.</returns>
        List<TicketResponseDto> GetAllTickets();

        /// <summary>
        /// Retrieves all tickets submitted by a specific member.
        /// </summary>
        /// <param name="memberId">The member's identifier.</param>
        /// <returns>A list of DTOs representing the member's tickets.</returns>
        List<TicketResponseDto> GetTicketsByMemberId(int memberId);
    }
}
