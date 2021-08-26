using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Brand : CommonEntity
    {
        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string LogoPath { get; set; }

        [Required]
        public int SlNo { get; set; }
    }
}
