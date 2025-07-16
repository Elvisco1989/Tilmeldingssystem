using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models.Login
{
    /// <summary>
    /// Represents the login credentials and options for a user attempting to authenticate.
    /// </summary>
    public class Login
    {
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
        /// Gets or sets a value indicating whether the user wants to remain logged in.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
