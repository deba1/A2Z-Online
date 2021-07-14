using Domain.Common;
using System;

namespace Domain.Entities
{
    public class UserCredential : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual User User { get; set; }
    }
}
