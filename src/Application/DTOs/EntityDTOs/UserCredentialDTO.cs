using Domain.Entities;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class UserCredentialDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool EmailVerified { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

        [Required]
        public DateTime LastLogin { get; set; }
        public virtual User User { get; set; }
    }
}
