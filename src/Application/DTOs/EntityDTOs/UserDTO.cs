using Domain.Enums;
using System;

namespace Application.DTOs.EntityDTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}
