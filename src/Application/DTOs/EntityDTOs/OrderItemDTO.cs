using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class OrderItemDTO
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
        public decimal Price { get; set; }
    }
}
