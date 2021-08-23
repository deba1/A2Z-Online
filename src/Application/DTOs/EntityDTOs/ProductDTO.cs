using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public string AdditionalFields { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }
    }
}
