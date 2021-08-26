using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }

        [Required, MaxLength(25)]
        public string Method { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
        public decimal TotalAmount { get; set; }

        [Required, MaxLength(10)]
        public string Currency { get; set; }

        [Required, MaxLength(25)]
        public string Status { get; set; }

        [Required, MaxLength(50)]
        public string TransactionId { get; set; }

        [Required, MaxLength(255)]
        public string SessionKey { get; set; }

        [Required]
        public DateTime PaymentTime { get; set; }
        public virtual Order Order { get; set; }
    }
}
