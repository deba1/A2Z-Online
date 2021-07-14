using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Brand : CommonEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoPath { get; set; }

        [Required]
        public int SlNo { get; set; }
    }
}
