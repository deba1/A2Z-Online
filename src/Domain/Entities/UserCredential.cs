using Domain.Common;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserCredential : BaseEntity
    {
        [Required]
        [ForeignKey("User")]
        public override int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [Required]
        public bool EmailVerified { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        [Required]
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
    }
}
