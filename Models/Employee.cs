using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        [MaxLength(100)]
        public string LastName { get; set; } = "";

        [MaxLength(100)]
        public string Position { get; set; } = "";

        [MaxLength(10)] 
        public string PhoneNumber { get; set; } = "";
        [MaxLength(100)]
        public string Email { get; set; } = "";
        public string ImageFileName { get; set; } = "";

        public DateTime HireDate { get; set; }



    }
}