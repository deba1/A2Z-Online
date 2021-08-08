using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool EmailVerified { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
