using System;
using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents a registration of a member to an activity.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Primary key for the registration.
        /// </summary>
        [Key]
        public int RegistrationId { get; set; }

        /// <summary>
        /// Foreign key referencing the member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Navigation property to the member.
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Foreign key referencing the activity.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Navigation property to the activity.
        /// </summary>
        public Activity Activity { get; set; }

        /// <summary>
        /// Date when the registration was created.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Status of the registration, e.g., "betalt" (paid), "venter" (pending).
        /// </summary>
        public string Status { get; set; }
    }
}
