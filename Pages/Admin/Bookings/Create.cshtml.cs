using System;
using System.Collections.Generic;
using System.Linq;
using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mgmt1.Pages.Admin.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();
        public List<SelectListItem> Rooms { get; set; } = new List<SelectListItem>();
        public string errorMessage = "";
        public string successMessage = "";

        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            PopulateRooms();
        }

        public void OnPost()
        {
            // Logic for handling form submission
        }

        private void PopulateRooms()
        {
            Rooms = context.Rooms
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                })
                .ToList();
        }
    }
}
