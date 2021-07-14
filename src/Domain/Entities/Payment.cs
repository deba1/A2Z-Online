using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Total Amount; Max 18 digits")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string TransactionId { get; set; }

        [Required]
        public string SessionKey { get; set; }

        [Required]
        public DateTime PaymentTime { get; set; }
        public virtual Order Order { get; set; }
    }
}
