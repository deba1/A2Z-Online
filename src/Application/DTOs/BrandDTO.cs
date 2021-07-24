using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class BrandDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoPath { get; set; }

        [Required]
        public int SlNo { get; set; }
    }
}
