using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(4000)]
        public string ShippingAddress { get; set; }

        [Required, MaxLength(25)]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
        public decimal DeliveryCharge { get; set; }

        [Required]
        public EnumOrderStatus Status { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
