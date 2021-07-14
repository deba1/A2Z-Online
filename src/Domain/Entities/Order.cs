﻿using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
        public decimal DeliveryCharge { get; set; }
        public int Status { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
