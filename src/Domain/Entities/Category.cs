using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Category : CommonEntity
    {
        [Required, MaxLength(25)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string Thumbnail { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> CategoryChildren { get; set; }
        public virtual Category CategoryParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
