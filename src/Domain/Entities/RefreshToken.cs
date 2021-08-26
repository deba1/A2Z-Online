using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        [MaxLength(600)]
        public string Token { get; set; }

        [MaxLength(255)]
        public string JwtId { get; set; }

        [Required]
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserCredential User { get; set; }
    }
}
