using Domain.Common;

namespace Domain.Entities
{
    class UserCredential : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
