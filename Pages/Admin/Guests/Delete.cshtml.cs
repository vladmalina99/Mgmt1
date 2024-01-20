using Mgmt1.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace Mgmt1.Pages.Admin.Guests
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
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


        }
    }
}
