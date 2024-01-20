using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mgmt1.Models
{
    public class EmployeeDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = "";

        [Required, MaxLength(100)]
        public string LastName { get; set; } = "";

        [Required, MaxLength(100)]
        public string Position { get; set; } = "";

        [MaxLength(10)] 
        public string PhoneNumber { get; set; } = "";

        [MaxLength(100)]
        public string Email { get; set; } = "";

        public IFormFile? ImageFile { get; set; }
    
    }
}
