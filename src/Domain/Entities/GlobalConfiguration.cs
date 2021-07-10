using Domain.Common;

namespace Domain.Entities
{
    class GlobalConfiguration : BaseEntity
    {
        public string KeyId { get; set; }

        public string Value { get; set; }

    }
}
