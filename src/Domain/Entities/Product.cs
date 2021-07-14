using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public string AdditionalFields { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }   
    }
}
