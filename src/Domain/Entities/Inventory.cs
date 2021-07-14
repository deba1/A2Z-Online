using Domain.Common;

namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
