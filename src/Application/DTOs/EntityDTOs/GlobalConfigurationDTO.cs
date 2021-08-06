using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class GlobalConfigurationDTO
    {
        [Required]
        public string KeyId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
