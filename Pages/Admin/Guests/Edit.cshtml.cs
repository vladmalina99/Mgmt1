using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Mgmt1.Pages.Admin.Guests
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public GuestDto GuestDto { get; set; } = new GuestDto();

        public Guest Guest { get; set; } = new Guest();

        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Guests/Index");
                return;
            }

            var guest = context.Guests.Find(id);
            if (guest == null)
            {
                Response.Redirect("/Admin/Guests/Index");
                return;
            }

            GuestDto.FirstName = guest.FirstName;
            GuestDto.LastName = guest.LastName;
            GuestDto.PhoneNumber = guest.PhoneNumber;
            GuestDto.Email = guest.Email;
            GuestDto.CheckInDate = guest.CheckInDate;
            GuestDto.CheckOutDate = guest.CheckOutDate;

            Guest = guest;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Guests/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var guest = context.Guests.Find(id);
            if (guest == null)
            {
                Response.Redirect("/Admin/Guests/Index");
            }

            // Update the guest in the database
            guest.FirstName = GuestDto.FirstName;
            guest.LastName = GuestDto.LastName;
            guest.PhoneNumber = GuestDto.PhoneNumber;
            guest.Email = GuestDto.Email ?? "";
            guest.CheckInDate = GuestDto.CheckInDate;
            guest.CheckOutDate = GuestDto.CheckOutDate;

            context.SaveChanges();

            Guest = guest;
            successMessage = "Guest updated successfully";

            Response.Redirect("/Admin/Guests/Index");
        }
    }
}
