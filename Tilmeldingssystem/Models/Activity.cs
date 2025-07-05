using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int ClubId { get; set; }
    }
}
