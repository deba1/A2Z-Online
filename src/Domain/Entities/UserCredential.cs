using Domain.Common;
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
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
    }
}
