using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Application.DTOs.EntityDTOs
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
        public decimal DeliveryCharge { get; set; }
        public EnumOrderStatus Status { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
