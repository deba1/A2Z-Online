using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class GlobalConfiguration : BaseEntity
    {
        [Required, MaxLength(25)]
        public string KeyId { get; set; }

        [Required, MaxLength(255)]
        public string Value { get; set; }
    }
}
