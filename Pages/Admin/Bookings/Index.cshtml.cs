using System;
using System.Collections.Generic;
using System.Linq;
using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Mgmt1.Pages.Admin.Bookings
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            Bookings = context.Bookings
                .Include(b => b.Room)
                .OrderByDescending(b => b.BookingId)
                .ToList();
        }
    }
}
