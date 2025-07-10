using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.TicketSystem;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public ActionResult<TicketResponseDto> CreateTicket([FromBody] CreateTicketDto ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Ticket cannot be null.");
            }

            var createdTicket = _ticketService.CreateTicket(ticket);
            if (createdTicket == null)
            {
                return BadRequest("Failed to create ticket.");
            }

            return Ok(ticket);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TicketResponseDto>> GetAllTickets()
        {
            var tickets = _ticketService.GetAllTickets();
            if (tickets == null || !tickets.Any())
            {
                return NotFound("No tickets found.");
            }

            return Ok(tickets);
        }
    }
}
