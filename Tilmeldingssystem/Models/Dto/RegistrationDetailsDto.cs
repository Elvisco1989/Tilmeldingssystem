namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// Data transfer object representing detailed information about a registration.
    /// </summary>
    public class RegistrationDetailsDto
    {
        /// <summary>
        /// Gets or sets the full name of the member who registered.
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// Gets or sets the name of the registered activity.
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// Gets or sets the start time of the activity.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the activity.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the location where the activity takes place.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the price of the activity.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the registration status (e.g., "paid", "pending").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date when the registration was made.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}
