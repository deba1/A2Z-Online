using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public string AdditionalFields { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }   
    }
}
