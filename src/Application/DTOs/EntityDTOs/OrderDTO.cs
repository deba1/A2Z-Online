using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class OrderDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
        public decimal DeliveryCharge { get; set; }

        [Required]
        public EnumOrderStatus Status { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
