using Stripe;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.AppDbcontext;

namespace Tilmeldingssystem.Services
{
    public class PaymentService
    {
        private readonly TilmeldingsDbContext _context;
        private readonly IStripeClient _stripeClient;

        public PaymentService(TilmeldingsDbContext context, IStripeClient stripeClient)
        {
            _context = context;
            _stripeClient = stripeClient;
        }

        /// <summary>
        /// Creates a Stripe PaymentIntent for a member activity registration.
        /// </summary>
        public PaymentIntent CreateActivityPaymentIntent(MemberActivity memberActivity)
        {
            // Get the related activity from DB
            var activity = _context.Activities.FirstOrDefault(a => a.ActivityId == memberActivity.ActivityId);
            if (activity == null)
            {
                throw new ArgumentException("Activity not found.");
            }

            var amountInCents = (long)(activity.Price * 100); // Stripe works in smallest currency units

            var options = new PaymentIntentCreateOptions
            {
                Amount = amountInCents,
                Currency = "dkk",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
                Description = $"Payment for activity: {activity.Name}",
            };

            var service = new PaymentIntentService(_stripeClient);
            var intent = service.Create(options);

            // You could optionally store the intent.Id or status in your DB here

            return intent;
        }
    }
}
