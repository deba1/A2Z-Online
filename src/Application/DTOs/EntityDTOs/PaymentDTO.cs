using System;

namespace Application.DTOs.EntityDTOs
{
    public class PaymentDTO
    {
        public int OrderId { get; set; }
        public string Method { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public string SessionKey { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}
