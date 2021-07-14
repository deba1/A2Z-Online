using Domain.Common;

namespace Domain.Entities
{
    public class GlobalConfiguration : BaseEntity
    {
        public string KeyId { get; set; }
        public string Value { get; set; }
    }
}
