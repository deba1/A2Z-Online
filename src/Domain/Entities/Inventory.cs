using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Unit Price; Max 18 digits")]
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
