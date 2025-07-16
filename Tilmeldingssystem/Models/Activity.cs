using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents an activity with details like name, timing, location, price, and participating members.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Primary key for the Activity.
        /// </summary>
        [Key]
        public int ActivityId { get; set; }

        /// <summary>
        /// Name of the activity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the activity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Start time of the activity.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of the activity.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Location where the activity takes place.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Price to participate in the activity.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property to the members participating in the activity.
        /// </summary>
        public ICollection<MemberActivity> MemberActivities { get; set; } = new List<MemberActivity>();
    }
}
