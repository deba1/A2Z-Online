using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class PaymentDTO
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
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
    }
}
