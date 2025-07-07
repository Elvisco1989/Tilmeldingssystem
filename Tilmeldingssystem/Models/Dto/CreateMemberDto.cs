﻿namespace Tilmeldingssystem.Models.Dto
{
    public class CreateMemberDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
