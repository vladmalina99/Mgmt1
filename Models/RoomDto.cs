using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Models
{
    public class RoomDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}