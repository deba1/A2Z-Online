using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class FeedbackDTO
    {
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Score Must be between 1 to 5")]
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
