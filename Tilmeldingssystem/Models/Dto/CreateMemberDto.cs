namespace Tilmeldingssystem.Models.Dto
{
    /// <summary>
    /// DTO for creating a new member with necessary personal details.
    /// </summary>
    public class CreateMemberDto
    {
        /// <summary>
        /// Gets or sets the full name of the member.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the member.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the member.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of birth of the member.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
