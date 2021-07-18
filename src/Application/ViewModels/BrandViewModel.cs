using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BrandViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoPath { get; set; }

        [Required]
        public int SlNo { get; set; }
    }
}
