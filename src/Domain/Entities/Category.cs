using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : CommonEntity
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> CategoryChildren { get; set; }
        public virtual Category CategoryParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
