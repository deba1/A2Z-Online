using Domain.Entities;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class UserCredentialDTO
    {
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer;
        public DateTime LastLogin { get; set; }
        public virtual User User { get; set; }
    }
}
