using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class GlobalConfiguration : BaseEntity
    {
        [Required]
        public string KeyId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
