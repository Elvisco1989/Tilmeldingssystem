namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// DTO for creating a new activity with details about schedule, location, and pricing.
    /// </summary>
    public class CreateActivityDto
    {
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the activity.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the start time of the activity.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the activity.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the location of the activity.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the activity.
        /// </summary>
        public decimal Price { get; set; }
    }
}
