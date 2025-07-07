using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }  // fx "betalt", "venter"
    }

}
