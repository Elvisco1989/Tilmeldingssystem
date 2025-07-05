﻿using System.ComponentModel.DataAnnotations;

namespace Tilmeldingssystem.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
