using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }  // fx "succes", "fejlet"
        public string PaymentMethod { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
