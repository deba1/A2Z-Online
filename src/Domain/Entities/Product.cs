using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, MaxLength(255)]
        public string Thumbnail { get; set; }

        [MaxLength(4000)]
        public string Images { get; set; }

        [MaxLength(4000)]
        public string AdditionalFields { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }   
    }
}
