using Domain.Common;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
