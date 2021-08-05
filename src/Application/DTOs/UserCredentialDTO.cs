using Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserCredentialDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }
        public virtual User User { get; set; }
    }
}
