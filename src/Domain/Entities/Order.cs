using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Delivery Charge; Max 18 digits")]
        public decimal DeliveryCharge { get; set; }

        [Required]
        public int Status { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
