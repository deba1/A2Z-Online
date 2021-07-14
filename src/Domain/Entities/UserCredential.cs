using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserCredential : BaseEntity
    {
        [Required]
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
