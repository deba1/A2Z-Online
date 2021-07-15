﻿using Domain.Common;
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
        [Range(1, 5, ErrorMessage = "Score Must be between 1 to 5")]
        public string Age { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
