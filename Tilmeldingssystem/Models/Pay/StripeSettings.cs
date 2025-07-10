namespace Tilmeldingssystem.Models.Pay
{
    public class StripeSettings
    {
        /// <summary>
        /// Offentlig nøgle (Publishable Key) til Stripe – bruges på klientsiden.
        /// </summary>
        public string PublishableKey { get; set; }

        /// <summary>
        /// Hemmelig nøgle (Secret Key) til Stripe – bruges på serversiden.
        /// Skal beskyttes og aldrig eksponeres i frontend.
        /// </summary>
        public string SecretKey { get; set; }
    }
}
