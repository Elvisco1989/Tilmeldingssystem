﻿namespace Tilmeldingssystem.Models.Dto
{
    public class CreateActivityDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
