using System;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Models
{
    public class BookingDto
    {
        [Required]
        public int RoomId { get; set; }

        [Required, MaxLength(50)]
        public string RoomNumber { get; set; } = "";

        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;
    }
}
