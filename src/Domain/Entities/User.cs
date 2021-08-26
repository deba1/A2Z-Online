using Domain.Common;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(25)]
        public string MobileNo { get; set; }

        [Required, MaxLength(4000)]
        public string Address { get; set; }

        [JsonIgnore]
        public virtual UserCredential UserCredential { get; set;}
    }
}
