using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Thumbnail { get; set; }
        public int? ParentId { get; set; }
    }
}
