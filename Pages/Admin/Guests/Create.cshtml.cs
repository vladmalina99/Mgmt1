using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Mgmt1.Models;
using Mgmt1.Services;

namespace Mgmt1.Pages.Admin.Guests
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public GuestDto GuestDto { get; set; } = new GuestDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {
            // Metoda OnGet pentru înc?rcarea paginii de creare
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost()
        {
            // Verific? dac? modelul este valid înainte de a salva în baza de date
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            // Creeaz? un obiect Guest pe baza datelor din GuestDto
            Guest guest = new Guest
            {
                FirstName = GuestDto.FirstName,
                LastName = GuestDto.LastName,
                PhoneNumber = GuestDto.PhoneNumber,
                Email = GuestDto.Email ?? "",
                CheckInDate = GuestDto.CheckInDate ?? DateTime.MinValue,
                CheckOutDate = GuestDto.CheckOutDate ?? DateTime.MaxValue,
            };

            // Adaug? obiectul Guest în contextul bazei de date ?i salveaz? schimb?rile
            context.Guests.Add(guest);
            context.SaveChanges();

            // Cur??? formularul
            GuestDto.FirstName = "";
            GuestDto.LastName = "";
            GuestDto.PhoneNumber = "";
            GuestDto.Email = "";
            GuestDto.CheckInDate = DateTime.Now; // Po?i folosi o alt? valoare implicit?
            GuestDto.CheckOutDate = DateTime.Now.AddDays(1); // Po?i folosi o alt? valoare implicit?

            ModelState.Clear();

            successMessage = "Guest created successfully";

            // Redirecteaz? c?tre pagina de listare a oaspe?ilor
            Response.Redirect("/Admin/Guests/Index");
        }
    }
}
