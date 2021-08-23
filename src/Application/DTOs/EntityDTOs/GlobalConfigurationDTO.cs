using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EntityDTOs
{
    public class GlobalConfigurationDTO
    {
        [Required]
        public string KeyId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
