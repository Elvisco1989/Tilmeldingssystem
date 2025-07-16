using System;
using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents a payment related to a registration.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Primary key for the payment.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key referencing the registration.
        /// </summary>
        public int RegistrationId { get; set; }

        /// <summary>
        /// Amount paid.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Status of the payment, e.g., "succes" (success), "fejlet" (failed).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Payment method used.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Timestamp when the payment was made.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
