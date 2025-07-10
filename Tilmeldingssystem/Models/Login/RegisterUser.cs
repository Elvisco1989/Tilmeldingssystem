using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models.Login
{
    public class RegisterUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation did not match")]
        public string ConfirmPassword { get; set; }

        // Add the following
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
