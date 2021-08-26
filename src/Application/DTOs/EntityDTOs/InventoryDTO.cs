using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class InventoryDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2}){0,1}$")]
        public decimal UnitPrice { get; set; }
    }
}
