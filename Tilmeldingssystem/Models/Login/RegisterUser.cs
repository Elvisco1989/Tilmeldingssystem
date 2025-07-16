using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models.Login
{
    /// <summary>
    /// Represents the data required for registering a new user.
    /// </summary>
    public class RegisterUser
    {
        /// <summary>
        /// Gets or sets the unique identifier for the registered user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// This field is required and must be a valid email format.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// This field is required and is treated as a password input.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password confirmation.
        /// This field is required and must match the Password field.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation did not match")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// This field is optional.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// This field is optional.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the user's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
