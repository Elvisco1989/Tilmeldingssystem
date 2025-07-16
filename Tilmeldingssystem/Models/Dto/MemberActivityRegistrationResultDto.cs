namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Represents the result details after a member registers for an activity.
    /// Includes activity info, payment amount, member name, and payment intent secret.
    /// </summary>
    public class MemberActivityRegistrationResultDto
    {
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        public string ActivityName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location of the activity.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time of the activity.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the amount to be paid for the activity.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the full name of the member who registered.
        /// </summary>
        public string MemberName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client secret from the Stripe PaymentIntent.
        /// Used to complete the payment on the client side.
        /// </summary>
        public string PaymentIntentClientSecret { get; set; } = string.Empty;
    }
}
