using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Guests
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;
        public List<Guest> Guests { get; set; } = new List<Guest>();
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Guests = context.Guests.OrderByDescending(r => r.Id).ToList();
        }
    }
}