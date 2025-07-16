namespace Tilmeldingssystem.Models
{
    /// <summary>
    /// Represents the many-to-many relationship between a Member and an Activity.
    /// </summary>
    public class MemberActivity
    {
        /// <summary>
        /// Foreign key for Member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Navigation property to the Member.
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// Foreign key for Activity.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Navigation property to the Activity.
        /// </summary>
        public Activity Activity { get; set; }
    }
}
