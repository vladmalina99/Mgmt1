using System;
using System.Linq;
using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Booking Booking { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = context.Bookings.FirstOrDefault(b => b.BookingId == id);

            if (Booking == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = context.Bookings.Find(id);

            if (Booking != null)
            {
                context.Bookings.Remove(Booking);
                context.SaveChanges();
                return RedirectToPage("/Admin/Bookings/Index"); 
            }

            return NotFound();
        }
    }
}
