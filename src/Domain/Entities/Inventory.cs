using Domain.Common;

namespace Domain.Entities
{
    class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime AddedOn { get; set; }
        public virtual Product Product { get; set; }
    }
}
