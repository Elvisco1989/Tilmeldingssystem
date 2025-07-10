using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Services;

namespace Tilmeldingssystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly TilmeldingsDbContext _context;

        public PaymentController(PaymentService paymentService, TilmeldingsDbContext context)
        {
            _paymentService = paymentService;
            _context = context;
        }

        /// <summary>
        /// Creates a Stripe payment intent for a member's activity registration.
        /// </summary>
        /// <param name="memberActivityId">The ID of the member activity registration</param>
        /// <returns>PaymentIntent client secret for Stripe checkout</returns>
        [HttpPost("CreatePaymentIntent/{memberActivityId}")]
        public IActionResult CreatePaymentIntent(int memberActivityId)
        {
            // Validate the memberActivityId and get the MemberActivity entity
            var memberActivity = _context.MemberActivities.FirstOrDefault(ma => ma.MemberId == memberActivityId);
            if (memberActivity == null)
            {
                return NotFound(new { message = "Member activity not found." });
            }

            try
            {
                var paymentIntent = _paymentService.CreateActivityPaymentIntent(memberActivity);

                // Return client secret to frontend for Stripe checkout
                return Ok(new
                {
                    clientSecret = paymentIntent.ClientSecret,
                    paymentIntentId = paymentIntent.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
