using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public string Comment { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
