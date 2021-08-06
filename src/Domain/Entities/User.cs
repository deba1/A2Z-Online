﻿using Domain.Common;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public bool EmailVerified { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string Address { get; set; }

        [JsonIgnore]
        public virtual UserCredential UserCredential { get; set;}
    }
}
