using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CostumerDTO
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
