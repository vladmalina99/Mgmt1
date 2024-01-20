using System;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Models
{
    public class Guest
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        [MaxLength(100)]
        public string LastName { get; set; } = "";

        [MaxLength(10)]
        public string PhoneNumber { get; set; } = "";

        [MaxLength(100)]
        public string Email { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime? CheckInDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CheckOutDate { get; set; }
    }
}
